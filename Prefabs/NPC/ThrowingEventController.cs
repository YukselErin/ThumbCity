using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowingEventController : MonoBehaviour
{
    private RippleHandler rippleHandler;
    List<ThrowingEventNPC> throwingEventNPCs;
    void Awake()
    {
        throwingEventNPCs = new List<ThrowingEventNPC>();

    }
    void Start()
    {
        rippleHandler = GetComponent<RippleHandler>();
        rippleHandler.currentStory.BindExternalFunction("triggerThrowingEvent", () =>
       {
           ThowEventStart();
       });
        rippleHandler.currentStory.BindExternalFunction("endThrowingEvent", () =>
       {
           ThowEventEnd();
       });

    }
    public GameObject throwTarget;

    public void AddToThrowers(ThrowingEventNPC throwingEventNPC)
    {
        throwingEventNPCs.Add(throwingEventNPC);
        throwingEventNPC.throwTarget = throwTarget;
    }
    void ThowEventStart()
    {
        foreach (var thrower in throwingEventNPCs)
        {
            thrower.StartThrowing();
        }
    }
    
    public void ThowEventEnd()
    {
        foreach (var thrower in throwingEventNPCs)
        {
            thrower.EndThrowing();
        }
    }
}
