using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DialogueInitiate : MonoBehaviour
{
public string startingKnot;
    DialogueHandler dialogueHandler;

    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogueHandler>();
    }

    public void PlayerInteraction() { Init(); }
    void Init()
    {
        if (!dialogueHandler.inDialogue)
        {
            dialogueHandler.initiate(startingKnot);
        }

    }
}
