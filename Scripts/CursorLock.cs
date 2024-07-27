using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    bool lockState = true;
    public void cursorLocked(bool lockstate)
    {
        lockState = lockstate;
        changeState();
    }
    void OnApplicationFocus(bool hasFocus)
    {
        changeState();
    }
    void changeState()
    {
        Cursor.lockState = lockState ? CursorLockMode.Locked : CursorLockMode.None;

    }

    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = lockState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
