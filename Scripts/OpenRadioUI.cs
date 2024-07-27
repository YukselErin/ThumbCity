using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class OpenRadioUI : MonoBehaviour
{
    PlayerControls playercontrols;

    InputAction inputAction;
    public GameObject canvas;
    
    void Awake()
    {
        playercontrols = new PlayerControls();

    }
    void OnEnable()
    {
        inputAction = playercontrols.Player.Interact;
        inputAction.Enable();
        inputAction.performed += Interact;
    }
    void Interact(InputAction.CallbackContext context)
    {

        if (radioAvailable) { canvas.SetActive(true); }




    }
    void OnDisable()
    {
        inputAction.Disable();
    }
    bool radioAvailable = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>().currentStory.BindExternalFunction("radioAvailable", () =>
                {
                    radioAvailable = true;
                });
    }

    // Update is called once per frame
    public void RadioAvailable(bool state)
    {
        radioAvailable = state;

    }
}
