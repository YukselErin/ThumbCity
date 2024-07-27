using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DozerDitch : MonoBehaviour
{
    public BasementExplosion basementExplosion;
    TriggerRadio triggerRadio;
    DozerShooter dozerShooter;
    void Start()
    {
        triggerRadio = GameObject.FindGameObjectWithTag("GameController").GetComponent<TriggerRadio>();
        dozerShooter = dozerrigidbody.gameObject.GetComponent<DozerShooter>();
    }

    IEnumerator fallInDitch()
    {
        while (true)
        {
            if (basementExplosion.exploded)
            {
                navMeshAgent.enabled = false;
                dozerrigidbody.isKinematic = false;
                triggerRadio.trigger("JonathanTrapped", 5f);
                dozerShooter.enabled = false;
            }
            yield return null;
        }


    }

    public NavMeshAgent navMeshAgent;
    public Rigidbody dozerrigidbody;
    public NavMeshAgent tempmesh;
    public Rigidbody temprb;

    void OnTriggerEnter(Collider collider)

    {

        if (collider.gameObject.TryGetComponent(out tempmesh))
        {
            if (collider.gameObject.TryGetComponent(out temprb))
            {
                StartCoroutine(fallInDitch());
            }
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out tempmesh))
        {
            if (collider.gameObject.TryGetComponent(out temprb))
            {
                StopCoroutine(fallInDitch());
            }
        }


    }
}
