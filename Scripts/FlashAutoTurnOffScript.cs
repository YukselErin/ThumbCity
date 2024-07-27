using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAutoTurnOffScript : MonoBehaviour
{
    PlayerDozerTarget playerDozerTarget;
    public bool startCollider =false;
    void Start()
    {
    }

    FlashLight flashLight;
    void OnTriggerEnter(Collider collider)
    {
        playerDozerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDozerTarget>();

        if (collider.gameObject.TryGetComponent(out flashLight))
        {
            flashLight.turnedOn(startCollider);
            playerDozerTarget.followable = false;
            playerDozerTarget.startArea = startCollider;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        playerDozerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDozerTarget>();

        if (collider.gameObject.TryGetComponent(out flashLight))
        {
            flashLight.turnedOn(true);
            playerDozerTarget.followable = true;
            playerDozerTarget.startArea = false;

        }
    }
}
