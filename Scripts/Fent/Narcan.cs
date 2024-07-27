using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narcan : MonoBehaviour
{
    public GameObject explosionPrefab;
    GameObject exp;
    void Start()
    {
        exp = Instantiate(explosionPrefab);
        exp.SetActive(false);
    }
    void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.tag == "Bullet")
        {
            exp.transform.position = transform.position;
            exp.SetActive(true);
            exp.GetComponent<NarcanExplosion>().explode();
        }


    }
}
