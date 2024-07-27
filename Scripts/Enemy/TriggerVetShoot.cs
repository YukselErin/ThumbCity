using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVetShoot : MonoBehaviour
{
    private RippleHandler dialogueHandler;
    public EnemyShoot enemyShoot;
    TriggerRadio triggerRadio;
    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        dialogueHandler.currentStory.BindExternalFunction("vetShoots", () =>
        {
            trigger();
        });
        triggerRadio = GameObject.FindGameObjectWithTag("GameController").GetComponent<TriggerRadio>();
    }
    void trigger()
    {
        enemyShoot.Shoot();
    }
    float lastShot;
    public float cooldown = 0.7f;
    IEnumerator InCollider()
    {
        while (true)
        {
            if (Time.time > lastShot + cooldown && !dialogueHandler.inDialogue)
            {
                lastShot = Time.time;
                trigger();
            }
            yield return null;
        }

    }
    bool inTrigger = false;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Gun")
        {
            StartCoroutine(InCollider());
            triggerRadio.trigger("OldVet",-1f);
        }

    }
}
