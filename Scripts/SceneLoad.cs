using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    CarMove carMove;
    void Start()
    {
        carMove = GameObject.FindGameObjectWithTag("GameController").GetComponent<CarMove>();
    }

    // Update is called once per 
    public int startindex = 1;
    public void ChangeScene()
    {
        carMove.sirens();
        Invoke("coro", 2f);


    }
    void coro()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(startindex, LoadSceneMode.Single);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }
}
