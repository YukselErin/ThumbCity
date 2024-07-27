using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedCursor : MonoBehaviour
{
    CursorLock cursorLock;
    void Start()
    {
        cursorLock = GameObject.FindGameObjectWithTag("GameController").GetComponent<CursorLock>();
    }
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        cursorLock.cursorLocked(false);
    }

    // Update is called once per frame
    void OnDisable()
    {
        cursorLock = GameObject.FindGameObjectWithTag("GameController").GetComponent<CursorLock>();

        cursorLock.cursorLocked(true);

    }
}
