using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Mathematics;
using Ink.Runtime;
using SaveLoadSystem;
using System.Linq;
public class RippleHandler : MonoBehaviour, ISaveable
{
    [SerializeField] TextAsset inkAsset;
    [SerializeField] Dictionary<string, int> persistentDictionary;
    // Start is called before the first frame update
    public void setBool(string triggerName, bool boolean)
    {
        currentStory.variablesState[triggerName] = boolean;
    }
    public bool inDialogue = false;
    [SerializeField] int displayText = -1;
    [SerializeField] bool displayNextIndex;
    PlayerControls playerControls;
    InputAction interact;
    void Awake()
    {
        currentStory = new Story(inkAsset.text);
        playerControls = new PlayerControls();
        persistentDictionary = new Dictionary<string, int>();
        if (PlayerPrefs.HasKey("playerName"))
        {
            currentStory.variablesState["playerName"] = PlayerPrefs.GetString("playerName");
        }

    }

    void OnEnable()
    {
        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += PlayerInteract;
    }
    void OnDisable()
    {
        interact.Disable();
    }
    TextMeshProUGUI textmesh;
    public Story currentStory;
    public void initiate(string knot)
    {
        if (Time.time < cooldown + 1f)
        {
            return;
        }
        inDialogue = true;
        currentStory.ChoosePathString(knot);
        responseObject.gameObject.SetActive(true);
        nameContainer.SetActive(true);
        textmesh = responseObject.GetComponent<TextMeshProUGUI>();
        Cursor.lockState = CursorLockMode.None;

        foreach (var d in persistentDictionary)
        {
            currentStory.variablesState[d.Key] = d.Value;

        }
        Next();
    }
    bool waitPlayerResponse;
    int nextDisplayTextIndex;
    public float nextCD = 0.2f;
    float lastNext;
    void PlayerInteract(InputAction.CallbackContext context)
    {
        if (inDialogue)
        {

            Next();
        }
    }
    bool empty = false;
    void Next()
    {


        if (!empty && (currentStory == null || Time.time < lastNext + nextCD)) { return; }
        lastNext = Time.time;
        if (!currentStory.canContinue && currentStory.currentChoices.Count <= 0)
        {
            endDialogue();
            return;
        }


        if (currentStory.currentChoices.Count > 0)
        {
            loadPlayerResponses();
        }
        else
        {
            findNextResponse();
        }


    }
    void findNextResponse()
    {
        textmesh.text = currentStory.Continue();
        if (string.IsNullOrWhiteSpace(textmesh.text) || string.IsNullOrEmpty(textmesh.text))
        {
            empty = true;
            Next();
        }
        else
        {
            empty = false;
        }
        if (currentStory.currentTags != null && currentStory.currentTags.Count != 0)
        {
            nameContainer.GetComponentInChildren<TextMeshProUGUI>().text = currentStory.currentTags.First();
        }
        
    }
    public GameObject nameContainer;
    public GameObject responseObject;
    public GameObject ButtonParent;
    public GameObject buttonPrefab;
    public List<GameObject> buttons;
    void loadPlayerResponses()
    {
        List<Choice> choices = new List<Choice>();
        for (int i = 0; i < currentStory.currentChoices.Count; ++i)
        {
            Choice choice = currentStory.currentChoices[i];
            choices.Add(choice);
        }
        //Create Extra buttons if necessary
        while (choices.Count > buttons.Count)
        {
            GameObject temp = Instantiate(buttonPrefab, new Vector3(10f, buttons.Count * 3f, 0f) + pos, quaternion.identity);
            temp.transform.SetParent(ButtonParent.transform);
            buttons.Add(temp);
        }
        for (int i = 0; i < choices.Count; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i].text;
            buttons[i].GetComponent<DialogueButton>().index = choices[i].index;
            buttons[i].SetActive(true);
        }
        ButtonParent.gameObject.SetActive(true);

    }
    public Vector3 pos;
    public void sendButtonPress(int index)
    {
        currentStory.ChooseChoiceIndex(index);

        foreach (var v in buttons)
        {
            v.gameObject.SetActive(false);
        }
        ButtonParent.gameObject.SetActive(false);

        Next();

    }
    float cooldown = 0f;
    void endDialogue()
    {
        ButtonParent.SetActive(false);
        responseObject.SetActive(false);
        nameContainer.SetActive(false);

        inDialogue = false;
        Cursor.lockState = CursorLockMode.Locked;
        cooldown = Time.time;
    }
    public bool NeedsToBeSaved()
    {
        return true;
    }

    public bool NeedsReinstantiation()
    {
        return true;
    }

    [System.Serializable]
    struct BlockData
    {
        public string storyState;

    }

    public object SaveState()
    {
        Debug.Log("savestory");
        return new BlockData()
        {
            storyState = currentStory.state.ToJson()
        };
    }
    public void LoadState(object state)
    {
        BlockData data = (BlockData)state;
        Debug.Log("savestory");

        currentStory.state.LoadJson(data.storyState);
    }

    public void PostInstantiation(object state)
    {
    }

    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
    }
}
