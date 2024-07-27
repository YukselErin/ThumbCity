using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerRadio : MonoBehaviour
{
    private RippleHandler dialogueHandler;
    PlayerControls playerControls;
    InputAction openRadioAction;

    void Awake()
    {
        playerControls = new PlayerControls();
    }
    void OnEnable()
    {
        openRadioAction = playerControls.Player.Radio;
        openRadioAction.Enable();
        openRadioAction.performed += playerOpenRadio;

    }
    void playerOpenRadio(InputAction.CallbackContext context)
    {
        OpenRadio();
    }
    void OpenRadio()
    {
        if(dialogueHandler.inDialogue){
            return;
        }
        triggered = false;

        canvas.SetActive(false);
        if (triggeredKnot != null)
        {
            rippleInitiate.knot = triggeredKnot;
            rippleInitiate.PlayerInteraction();
            triggeredKnot = null;
        }
        else
        {
            rippleInitiate.knot = "Radio";
            rippleInitiate.PlayerInteraction();
        }
    }
    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        dialogueHandler.currentStory.BindExternalFunction("triggerRadio", (string knotName, float timeLimit) =>
        {
            trigger(knotName, timeLimit);
        });
        canvasInstance = Instantiate(canvas, transform);
        canvasInstance.SetActive(false);
    }
    public RippleInitiate rippleInitiate;
    // Update is called once per frame
    void Update()
    {

        if (triggered && Time.time > externalTriggerTime + timeLimitToForceAnswer)                  //can be optimized
        {
            OpenRadio();
        }
    }
    float externalTriggerTime = 0f;
    public bool triggered = false;
    float timeLimitToForceAnswer = -1;
    string triggeredKnot = null;
    public GameObject canvas;
    GameObject canvasInstance;

    public void trigger(string knotName, float timeLimit)
    {
        if (timeLimit >= 0f)
        {
            triggered = true;
            timeLimitToForceAnswer = timeLimit;
            externalTriggerTime = Time.time;
        }
        triggeredKnot = knotName;
        canvas.SetActive(true);
    }
}
