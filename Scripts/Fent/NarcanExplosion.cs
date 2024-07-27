using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarcanExplosion : MonoBehaviour
{
    GameObject player;
    void Start()
    {

    }
    FentStatus fentStatus;
    public float blastRadius = 30f;
    public void explode()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(transform.position, player.transform.position) <= blastRadius)
        {
            if (player.TryGetComponent(out fentStatus))
            {
                fentStatus.touchedNarcan();
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
