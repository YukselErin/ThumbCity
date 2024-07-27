using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Mathematics;

public class rippleold : MonoBehaviour
{

    [SerializeField] Dictionary<string, int> predicateInt;
    [SerializeField] Dictionary<string, int> prohibateInt;
    // Start is called before the first frame update
    public bool inDialogue = false;
    [SerializeField] int displayText = -1;
    [SerializeField] bool displayNextIndex;
    PlayerControls playerControls;
    InputAction interact;
    void Awake()
    {
        playerControls = new PlayerControls();
        predicateInt = new Dictionary<string, int>();
        prohibateInt = new Dictionary<string, int>();
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
    [SerializeField] DialogueCreator DialogueCreatorSO;
    TextMeshProUGUI textmesh;
    public void initiate(DialogueCreator dialogueTreeLoad)
    {
        inDialogue = true;
        DialogueCreatorSO = dialogueTreeLoad;
        responseObject.gameObject.SetActive(true);
        textmesh = responseObject.GetComponent<TextMeshProUGUI>();
        Cursor.lockState = CursorLockMode.None;
        Next();
    }
    bool waitPlayerResponse;
    int nextDisplayTextIndex;
    void PlayerInteract(InputAction.CallbackContext context)
    {
        Next();
    }
    void Next()
    {
        if (DialogueCreatorSO == null) { return; }
        if (predicateInt.ContainsKey("endDialogue"))
        {
            endDialogue();
            return;
        }
        if (!waitPlayerResponse)
        {
            int responseFound = findNextResponse();
            loadTextFromIndex(responseFound);
            waitPlayerResponse = predicateInt.ContainsKey("waitPlayerResponse");
            if (waitPlayerResponse)
            {
                loadPlayerResponses();
            }
        }


    }
    int findNextResponse()
    {
        int maxPreds = 0;
        int indexToDisplay = 0;

        for (int index = 0; index < DialogueCreatorSO.entries.Length; index++)
        {
            int preds = 0;
            bool elligible = true;
            for (int i = 0; i < DialogueCreatorSO.entries[index].predicates.Length; i++)
            {
                if (predicateInt.ContainsKey(DialogueCreatorSO.entries[index].predicates[i]))
                {
                    preds++;
                }
                else
                {
                    elligible = false;
                    break;
                }
            }
            for (int i = 0; i < DialogueCreatorSO.entries[index].prohibates.Length; i++)
            {
                if (predicateInt.ContainsKey(DialogueCreatorSO.entries[index].predicates[i]))
                {
                    elligible = false;
                    break;

                }
                else
                {
                    preds++;
                }
            }
            if (elligible && (preds > maxPreds))
            {
                indexToDisplay = index;
                maxPreds = preds;
            }
        }
        Debug.Log("indexToDisplay " + indexToDisplay);
        for (int i = 0; i < DialogueCreatorSO.entries[indexToDisplay].setsPredicates.Length; i++)
        {
            Debug.Log("predno " + i);
            predicateInt.Add(DialogueCreatorSO.entries[indexToDisplay].setsPredicates[i], 1);
        }
        for (int i = 0; i < DialogueCreatorSO.entries[indexToDisplay].setsProhibates.Length; i++)
        {
            prohibateInt.Add(DialogueCreatorSO.entries[indexToDisplay].setsProhibates[i], 1);
        }
        return indexToDisplay;
    }
    public GameObject responseObject;
    public GameObject ButtonParent;
    public GameObject buttonPrefab;
    public List<GameObject> buttons;
    void loadPlayerResponses()
    {
        List<int> indexToDisplay = new List<int>();

        for (int index = 0; index < DialogueCreatorSO.responses.Length; index++)
        {
            bool elligible = true;
            for (int i = 0; i < DialogueCreatorSO.responses[index].predicates.Length; i++)
            {
                if (predicateInt.ContainsKey(DialogueCreatorSO.responses[index].predicates[i]))
                {

                }
                else
                {
                    elligible = false;
                    break;
                }
            }
            for (int i = 0; i < DialogueCreatorSO.responses[index].prohibates.Length; i++)
            {
                if (prohibateInt.ContainsKey(DialogueCreatorSO.responses[index].prohibates[i]))
                {
                    elligible = false;
                    break;

                }
                else
                {
                }
            }
            if (elligible)
            {
                indexToDisplay.Add(index);
            }
        }

        //Create Extra buttons if necessary
        while (indexToDisplay.Count > buttons.Count)
        {
            GameObject temp = Instantiate(buttonPrefab, new Vector3(10f, buttons.Count * 3f, 0f) + pos, quaternion.identity);
            temp.transform.SetParent(ButtonParent.transform);
            buttons.Add(temp);
        }
        for (int i = 0; i < indexToDisplay.Count; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = DialogueCreatorSO.responses[indexToDisplay[i]].text;
            buttons[i].GetComponent<DialogueButton>().index = indexToDisplay[i];
            buttons[i].SetActive(true);
        }
    }
    public Vector3 pos;
    public void sendButtonPress(int index)
    {
        for (int i = 0; i < DialogueCreatorSO.responses[index].setsPredicates.Length; i++)
        {
            predicateInt.Add(DialogueCreatorSO.responses[index].setsPredicates[i], 1);
        }
        for (int i = 0; i < DialogueCreatorSO.responses[index].setsProhibates.Length; i++)
        {
            prohibateInt.Add(DialogueCreatorSO.responses[index].setsProhibates[i], 1);
        }
        predicateInt.Remove("waitPlayerResponse");

        Next();
        foreach (var v in buttons)
        {
            v.gameObject.SetActive(false);
        }
    }

    void endDialogue()
    {
        ButtonParent.SetActive(false);
        responseObject.SetActive(false);
        DialogueCreatorSO = null;
        inDialogue = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void loadTextFromIndex(int index)
    {
        textmesh.text = DialogueCreatorSO.entries[index].text;
    }
}
