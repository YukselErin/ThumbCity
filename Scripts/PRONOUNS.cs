using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using StarterAssets;
using UnityEngine;

public class PRONOUNS : MonoBehaviour
{
    GameObject player;
    RippleHandler rippleHandler;
    public GameObject canvas;
    public GameObject initiator;
    public RippleInitiate partner;
    OpenRadioUI openRadioUI;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rippleHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        rippleHandler.currentStory.BindExternalFunction("pronouns", () =>
        {
            pronouns();
            initiator.GetComponent<RippleInitiate>().interactable = false;
        });
        rippleHandler.currentStory.BindExternalFunction("name", () =>
        {
            namecan();
            initiator.GetComponent<RippleInitiate>().interactable = false;
        });
        if (PlayerPrefs.HasKey("playerName"))
        {
            partner.interactable = false;
            GetComponent<OpenRadioUI>().RadioAvailable(true);
        }
    }


    // Update is called once per frame
    void pronouns()
    {
        canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
    }
    public GameObject nameCanvas;
    void namecan()
    {
        nameCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;

    }
    public void pronounSet(string set)
    {
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        rippleHandler.currentStory.variablesState["playerPronouns"] = set; partner.interactable = true;
    }
    public void nameSet(string set)
    {
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetString("playerName", set);
        rippleHandler.currentStory.variablesState["playerName"] = set; partner.interactable = true;
    }
}
