using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    RippleHandler rippleHandler;
    void Start()
    {
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();

    }
    public Death[] protesters;

    // Update is called once per frame
    public void updateStory()
    {
        bool temp = false;
        foreach (var death in protesters)
        {
            if (!death.dead) { temp = true; }
        }
        if (!temp)
        {
            Debug.Log("protestersDealt");
            rippleHandler.currentStory.variablesState["protestersDealt"] = true;
        }
    }
}
