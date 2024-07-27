using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class VolumeController : MonoBehaviour
{
    public Volume currentvolume;
    void Start()
    {
        currentvolume.profile.TryGet<Vignette>(out vignette);
        vignetteDefaultIntensity = vignette.intensity.GetValue<float>();
    }
    Vignette vignette;
    public float blackoutrate = 1f;
    float currentIntensity;
    float vignetteDefaultIntensity;
    public void RestoreBlackout()
    {
        StopAllCoroutines();
        vignette.intensity.Override(vignetteDefaultIntensity);
    }
    public void Blackout() { StartCoroutine(blackout()); }
    IEnumerator blackout()
    {
        while (currentIntensity < 10f)
        {

            currentIntensity = vignette.intensity.GetValue<float>();
            ClampedFloatParameter blackout = new ClampedFloatParameter(currentIntensity + Time.deltaTime * blackoutrate, 0f, 1f, false);
            vignette.intensity.Override(currentIntensity + Time.deltaTime * blackoutrate);
            yield return null;
        }
        currentIntensity=0f;
        StopAllCoroutines();
    }
    void Update()
    {

    }
}
