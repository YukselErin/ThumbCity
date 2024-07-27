using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public int index;
    public void Pressed()
    {
        rippleHandler.sendButtonPress(index);
    }
    RippleHandler rippleHandler;
    void Start()
    {
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
