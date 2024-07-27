using System.Collections;
using System.Collections.Generic;
using SaveLoadSystem;
using UnityEngine;


public class SavePoint : MonoBehaviour
{
    SavePointController savePointController;
    public bool defaultSave = false;

    void Start()
    {
        savePointController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SavePointController>();
        if (defaultSave) { PlayerInteraction(); }
    }
    public float rotateSpeed = 10f;
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            savePointController.saveCanvas.SetActive(true);

        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            savePointController.saveCanvas.SetActive(false);
        }

    }
    public void PlayerInteraction()
    {
        savePointController.setLatest(this.gameObject);
        SaveLoadSystem.SaveLoadSystem.SaveNew();
    }
}
