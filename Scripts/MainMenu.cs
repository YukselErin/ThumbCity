using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class MainMenu : MonoBehaviour
{
    public CinemachineVirtualCamera mainMenuCamera;
    PlayerControls playerControls;
    InputAction escape;
    public bool gameStarted = false;
    AudioSource audioSource;
    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        escape = playerControls.Player.Menu;
        escape.Enable();
        escape.performed += escapePressed;
    }
    void OnDisable()
    {
        escape.Disable();

    }
    bool act = false;
    void escapePressed(InputAction.CallbackContext context)
    {
        if (!gameStarted) return;
        Time.timeScale = 0;
        transform.GetChild(0).gameObject.SetActive(!act);
        mainMenuCamera.enabled = true;
    }
    void Start()
    {
        Time.timeScale = 0f;
        if (PlayerPrefs.HasKey("playerName")) gameStarted = true;
        audioSource = GetComponent<AudioSource>();
        if (!gameStarted)
        {
            if (audioSource) audioSource.Play();
        }
        else
        {
            StartGame(); transform.GetChild(0).gameObject.SetActive(false); Time.timeScale = 1f;
        }


    }
    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;
        if (audioSource) audioSource.Stop();
        mainMenuCamera.enabled = false;

    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
