using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
public class RippleInitiate : MonoBehaviour
{
    RippleHandler rippleHandler;
    public string knot;
    public bool interactable = true;
    void Start()
    {

        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
    }
    public void SetInteractable(bool set)
    {
        interactable = set;
    }
    public void PlayerInteraction() { if (interactable) { Init(); } }
    void Init()
    {
        if (!rippleHandler.inDialogue)
        {
            Debug.Log(knot);
            rippleHandler.initiate(knot);
        }

    }
}
