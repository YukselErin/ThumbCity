using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Intake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        triggerRadio = GameObject.FindGameObjectWithTag("GameController").GetComponent<TriggerRadio>();
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        rippleHandler.currentStory.BindExternalFunction("outOfTrip", () =>
        {
            startAfterDialogue();
        });
    }
    RippleHandler rippleHandler;
    TriggerRadio triggerRadio;
    Fent fent;
    public GameObject dozer;
    DozerShooter dozerShooter; NavMeshAgent navMeshAgent;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out fent))
        {
            triggerRadio.trigger("JonathanFentanylIntake", -1f);
            dozer.GetComponentInChildren<DozerShooter>().enabled = false;
            dozer.GetComponentInChildren<NavMeshAgent>().enabled = false;
            
        }
    }
    
    void startAfterDialogue()
    {
        
        dozer.GetComponentInChildren<DozerShooter>().enabled = true;
        dozer.GetComponentInChildren<NavMeshAgent>().enabled = true;
    }
}
