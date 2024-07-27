using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveLoadSystem;

public class FractureSave : MonoBehaviour, ISaveable
{
    public bool fractured =false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [System.Serializable]
    struct BlockData
    {
        public bool fractured;

    }

    public object SaveState()
    {
        return new BlockData()
        {
            fractured = fractured
        };
    }
    public void LoadState(object state)
    {
        BlockData data = (BlockData)state;
        fractured = data.fractured;
        Debug.Log("fracload"+fractured);
        if (!fractured)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i));
            }
        }
    }

    public bool NeedsToBeSaved()
    {
        return true;
    }
    public bool NeedsReinstantiation()
    {
        return true;
    }

    public void PostInstantiation(object state)
    {
        BlockData data = (BlockData)state;

    }
    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {

    }
}
