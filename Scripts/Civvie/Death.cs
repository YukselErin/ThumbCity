using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveLoadSystem;
using System.Data;
public class Death : MonoBehaviour, ISaveable
{

    DeathController deathController;
    void Start()
    {
        deathController = GameObject.FindGameObjectWithTag("GameController").GetComponent<DeathController>();
        sprite = Instantiate(spritePrefab, transform);
        sprite.SetActive(false);
    }
    public GameObject model;
    public GameObject spritePrefab;
    public GameObject sprite;
    public bool dead = false;
    public void shot()
    {
        dead = true;
        model.SetActive(false);
        sprite.SetActive(true);
        deathController.updateStory();
    }
    // Update is called once per frame
    public bool NeedsToBeSaved()
    {
        return true;
    }

    public bool NeedsReinstantiation()
    {
        return false;
    }

    [System.Serializable]
    struct BlockData
    {
        public bool isDead;

    }

    public object SaveState()
    {
        return new BlockData()
        {
            isDead = dead
        };
    }
    public void LoadState(object state)
    {
        BlockData data = (BlockData)state;
        dead = data.isDead;
        model.SetActive(!dead);
        sprite.SetActive(dead);
    }

    public void PostInstantiation(object state)
    {
    }

    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
    }
}
