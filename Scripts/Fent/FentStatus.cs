using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class FentStatus : MonoBehaviour
{
    PlayerHealth playerHealth;
    void Start()
    {
        volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<VolumeController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public VolumeController volume;
    public float narcanProtectionDuration = 0.5f;
    float narcanContactTime = 0f;

    public void touchedTrail()
    {
        if (Time.time < narcanContactTime + narcanProtectionDuration)
        {
        }
        else
        {
            //fentdeathanim
            playerHealth.dealDamage(200f);
        }
    }

    public void touchedNarcan()
    {
        narcanContactTime = Time.time;
        StopAllCoroutines();
        volume.RestoreBlackout();
    }
}
