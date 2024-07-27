using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class CatHead : MonoBehaviour
{
    public Cat catref;
    VisualEffect heartGraph;
    AudioSource audioSource;
    void Start()
    {
        heartGraph = GetComponentInChildren<VisualEffect>();
        audioSource = GetComponent<AudioSource>();
    }
GunTipPlacement gunTipPlacement;
    Fish fish;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out fish))
        {
            fish.eaten();
            catref.FedFish();
            heartGraph.Play();
        }else if(collider.TryGetComponent(out gunTipPlacement)){
            audioSource.Play();
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.TryGetComponent(out gunTipPlacement)){
            audioSource.Stop();
        }

    }
}
