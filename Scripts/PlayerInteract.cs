using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    PlayerControls playerControls;
    InputAction interact;
    void Awake()
    {
        playerControls = new PlayerControls();

    }

    void OnEnable()
    {
        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }
    void OnDisable()
    {
        interact.Disable();
    }
    void Interact(InputAction.CallbackContext context)
    {
        if (dialogueHandler.inDialogue)
        {
            return;
        }

        foreach (var hit in Physics.SphereCastAll(transform.position, 0.1f, transform.forward, 10f))
        {
            SavePoint tempscript;
            if (hit.transform.gameObject.TryGetComponent<SavePoint>(out tempscript))
            {
                tempscript.PlayerInteraction();
            }
            RippleInitiate rippleInitiate;
            if (hit.transform.gameObject.TryGetComponent<RippleInitiate>(out rippleInitiate))
            {
                rippleInitiate.PlayerInteraction();
            }
        }
    }
    RippleHandler dialogueHandler;

    // Update is called once per frame
    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();

    }
}
