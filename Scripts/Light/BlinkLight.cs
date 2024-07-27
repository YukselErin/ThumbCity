using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public float timeOffset;
    public float rate = 10f;
    public float max;
    Light light;
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame 
    bool increaseAlpha = false;
    void FixedUpdate()
    {
        if(timeOffset>Time.time ){return;}
        if (increaseAlpha)
        {
            if (light.intensity < max)
            {
                light.intensity = light.intensity + 0.2f * rate;
            }
            else
            {
                increaseAlpha = false;
            }
        }
        else
        {
            if (light.intensity > max)
            {
                light.intensity = light.intensity - 0.2f * rate;
            }
            else
            {
                increaseAlpha = true;
            }
        }
    }
}
