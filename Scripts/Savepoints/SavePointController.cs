using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointController : MonoBehaviour
{
    public GameObject saveCanvas;
    GameObject LatestSavePoint;
    GameObject player;
    VolumeController volume;
    PlayerHealth playerHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<VolumeController>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    public void setLatest(GameObject gameObject)
    {
        LatestSavePoint = gameObject;
    }
    public void load()
    {
        SaveLoadSystem.SaveLoadSystem.Load();
        StartCoroutine("tp");
        if (volume) volume.RestoreBlackout();

        playerHealth.restoreHp();

    }
    // Update is called once per frame
    IEnumerator tp()
    {
        for (int i = 0; i < 3; i++)
        {
            player.transform.position = LatestSavePoint.transform.position;
            yield return new WaitForSeconds(0.1f);
        }

    }
}
