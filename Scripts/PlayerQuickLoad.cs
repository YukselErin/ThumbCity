using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerQuickLoad : MonoBehaviour
{
    PlayerControls playerControls;
    InputAction quickLoad;
    SavePointController savePointController;
    void Start()
    {
        savePointController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SavePointController>();
    }
    void Awake()
    {
        playerControls = new PlayerControls();

    }

    void OnEnable()
    {
        quickLoad = playerControls.Player.QuickLoad;
        quickLoad.Enable();
        quickLoad.performed += Load;
    }
    void OnDisable()
    {
        quickLoad.Disable();
    }
    // Start is called before the first frame update
    void Load(InputAction.CallbackContext context)
    {
        savePointController.load();
        

    }

    // Update is called once per frame

}
