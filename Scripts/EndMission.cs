using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMission : MonoBehaviour
{

    public GameObject canvas;
    RippleHandler dialogueHandler;
    void Start()
    {
        dialogueHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<RippleHandler>();
        dialogueHandler.currentStory.BindExternalFunction("endMission", () =>
        {
            StartCoroutine(LoadScene());
        });

    }
    void endCanvas()
    {
        canvas.SetActive(true);
    }
    void deactivateCanvas()
    {
        canvas.SetActive(false);

    }
    public void returnToCarScene()
    {
        StartCoroutine(LoadScene());

    }
    IEnumerator LoadScene()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }

}
