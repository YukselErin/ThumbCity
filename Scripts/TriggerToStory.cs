using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToStory : MonoBehaviour
{
    private RippleHandler dialogueHandler;
    TriggerRadio triggerRadio;
    public string knotName;
    public float timeLimit = 5f;
    bool triggered = false;
    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        triggerRadio = GameObject.FindGameObjectWithTag("GameController").GetComponent<TriggerRadio>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player"&& !triggered)
        {

            triggered = true;
            triggerRadio.trigger(knotName, 5f);

        }
    }
}
