using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FentTrail : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    FentStatus fentStatus;

    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.gameObject.TryGetComponent(out fentStatus))
            {
                fentStatus.touchedTrail();
            }
            else
            {
                fentStatus = player.AddComponent(typeof(FentStatus)) as FentStatus;
                fentStatus.touchedTrail();
            }
        }
    }
}
