using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    Fracture fracture;
    PlayerHealth playerHealth;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Fracture>(out fracture))
        {
            fracture.CauseFracture();
        }
        if (collider.gameObject.TryGetComponent(out playerHealth))
        {
            playerHealth.dealDamage(1000f);
        }
    }
}
