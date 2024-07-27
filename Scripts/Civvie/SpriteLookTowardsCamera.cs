using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpriteLookTowardsCamera : MonoBehaviour
{
    //TODO: optimazable
    void Start()
    {
        InvokeRepeating("look", 0f, 0.2f);
    }

    // Update is called once per frame
    void look()
    {
        float t = Mathf.Max(Camera.main.transform.position.y);
        transform.SetPositionAndRotation(transform.position, quaternion.Euler(new float3(Mathf.PI * (t) / (180f), 0f, 0f)));


    }
}
