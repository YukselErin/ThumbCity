using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleDamage : MonoBehaviour
{
    RippleHandler rippleHandler;
    ThrowingEventController throwingEventController;
    void Start()
    {
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        throwingEventController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ThrowingEventController>();
        fracture = GetComponentInChildren<Fracture>();
    }
    public int hp = 10;
    Fracture temp;

    Fracture fracture;
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out temp) || collision.collider.tag == "Bullet")
        {
            hp--;
            if (hp == 0)
            {
                fracture.CauseFracture();
                rippleHandler.setBool("TowerDestroyed", true);
                throwingEventController.ThowEventEnd();
            }
        }

    }
}
