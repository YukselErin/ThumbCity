using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public bool flashLightOn = true;
    GunTipPlacement gunTipPlacement;
    Light light;
    void Start()
    {
        gunTipPlacement = GetComponent<GunTipPlacement>();
        gunTipPlacement.newAttachmentOnGunEvent.AddListener(NewAttachment);
        gunTipPlacement.gunShotEvent.AddListener(gunShot);

        if (!TryGetComponent(out light)) { this.enabled = false; }

    }
    FlashligtableObject flashligtableObject;
    void gunShot()
    {
        if (!this.enabled) { return; }
        if (flashligtableObject != null)
        {
            flashligtableObject.lightParent.SetActive(false);
        }

        flashligtableObject = null;
        light.enabled = flashLightOn;

    }

    void NewAttachment()
    {
        if (!this.enabled) { return; }

        flashligtableObject = GetComponentInChildren<FlashligtableObject>();
        if (flashligtableObject != null)
        {
            flashligtableObject.lightParent.SetActive(flashLightOn);
            light.enabled = false;
        }
    }
    public void turnedOn(bool state)
    {
        if (!this.enabled) { return; }


        if (flashligtableObject != null)
        {
            flashligtableObject.lightParent.SetActive(state);
        }
        else
        {
            light.enabled = state;
        }
        flashLightOn = state;
    }




    void Update()
    {

    }
}
