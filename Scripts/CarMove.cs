using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class CarMove : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    public Transform passengerSeatTransform;
    public List<GameObject> houses;
    public Transform startPoint;
    Volume volume;
    Vignette vignette;
    void Start()
    {
        volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<VolumeController>().currentvolume;
        volume.profile.TryGet<Vignette>(out vignette);
        StartCoroutine(fadein());
        SetScene();
        GetInCar();
    }
    public int houseAmount;
    public GameObject housePrefab;
    public GameObject trigger;
    void SetScene()
    {
        GameObject house;
        for (int i = 0; i < houseAmount; i++)
        {
            house = Instantiate(housePrefab, new Vector3(i * 49.5f, 0f, 0f), quaternion.identity);
            houses.Add(house);
        }
        startPoint.position = new Vector3((houseAmount - 1) * -49.5f, 0f, 0f);
        for (int i = 1; i < houseAmount; i++)
        {
            house = Instantiate(housePrefab, new Vector3(i * -49.5f, 0f, 0f), quaternion.identity);
            houses.Add(house);
        }
        trigger.transform.position = new Vector3((houseAmount) * 49.5f, 0f, 0f);

    }
    void GetInCar()
    {
        player.transform.position = passengerSeatTransform.position;
        player.transform.SetParent(car.transform, true);
        player.GetComponent<FirstPersonController>().Gravity = 0f;
        player.GetComponent<FirstPersonController>().Grounded = false;
        player.GetComponent<FirstPersonController>().MoveSpeed = 0f;

    }
    public Transform ListHouse(GameObject house)
    {

        return startPoint;
    }
    float currentIntensity;
    public float blackoutrate = 1f;
    public float blackoutstart = 10f;
    IEnumerator fadein()
    {
        vignette.intensity.Override(blackoutstart);
        for (float i = 10; i > 0.34f; i = currentIntensity)
        {
            currentIntensity = vignette.intensity.GetValue<float>();
            vignette.intensity.Override(currentIntensity - Time.deltaTime * blackoutrate);
            yield return null;
        }
        vignette.intensity.Override(0.34f);

    }

    public void sirens()
    {
        StartCoroutine(GoFaster());
        GetComponent<AudioSource>().Play();
    }
    IEnumerator GoFaster()
    {
        foreach (GameObject house in houses)
        {
            house.GetComponent<HouseMove>().MoveSpeed = 12f;
        }
        while (true)
        {
            foreach (GameObject house in houses)
            {
                house.GetComponent<HouseMove>().MoveSpeed = house.GetComponent<HouseMove>().MoveSpeed + 1f;
            }
            yield return null;
        }
    }
}
