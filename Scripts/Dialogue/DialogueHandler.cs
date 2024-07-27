using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.InputSystem;

public class DialogueHandler : MonoBehaviour
{
    Dictionary<string, int> dict;
    // Start is called before the first frame update
    public bool inDialogue = false;
    [SerializeField] int displayText = -1;
    [SerializeField] bool displayNextIndex;
    PlayerControls playerControls;
    InputAction interact;
    void Awake()
    {
        playerControls = new PlayerControls();
        dict = new Dictionary<string, int>();
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

    bool waitPlayerResponse;
    int nextDisplayTextIndex;
    void PlayerInteract(InputAction.CallbackContext context)
    {
        Next();
    }
    void Next()
    {
        if (dialogueTree == null) { return; }
        if (nextDisplayTextIndex == -1)
        {
            endDialogue();
            return;
        }
        if (!waitPlayerResponse)
        {
            loadTextFromTree(nextDisplayTextIndex);
            displayText = nextDisplayTextIndex;
            waitPlayerResponse = dialogueTree.dialogueResponses[displayText].waitPlayerResponse;
            nextDisplayTextIndex = dialogueTree.dialogueResponses[displayText].nextResponse;
            if (dialogueTree.dialogueResponses[displayText].waitPlayerResponse)
            {
                loadPlayerResponse();
            }
        }

    }
    void endDialogue()
    {
        foreach (var v in localizeStringEventPlayerResponse)
        {
            v.transform.parent.gameObject.SetActive(false);
        }
        localizeStringEventTDisplay.gameObject.SetActive(false);
        dialogueTree = null;
        inDialogue = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    void loadPlayerResponse()
    {
        for (int i = 0; i < dialogueTree.dialogueResponses[displayText].playerResponses.Length; i++)
        {
            int index = dialogueTree.dialogueResponses[displayText].playerResponses[i];
            localizeStringEventPlayerResponse[i].transform.parent.gameObject.SetActive(true);

            localizeStringEventPlayerResponse[i].StringReference = dialogueTree.dialogueResponses[index].text;
        }
    }
    [SerializeField] bool responseChosen;
    public void chooseResponse(int index)
    {
        if (waitPlayerResponse)
        {
            responseChosen = true;
            int chosen = dialogueTree.dialogueResponses[displayText].playerResponses[index];
            nextDisplayTextIndex = dialogueTree.dialogueResponses[chosen].nextResponse;
            waitPlayerResponse = false;
            foreach (var v in localizeStringEventPlayerResponse)
            {
                v.transform.parent.gameObject.SetActive(false);
            }
            Next();
        }

    }
    DialogueTree dialogueTree;
    [SerializeField] LocalizeStringEvent localizeStringEventTDisplay;
    [SerializeField] LocalizeStringEvent[] localizeStringEventPlayerResponse;
    string initiateString;

    public void initiate(string startingKnot)
    {
        inDialogue = true;

        nextDisplayTextIndex = 0;
        localizeStringEventTDisplay.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Next();
    }
    void loadTextFromTree(int index)
    {

        localizeStringEventTDisplay.StringReference = dialogueTree.dialogueResponses[index].text;
    }
}
