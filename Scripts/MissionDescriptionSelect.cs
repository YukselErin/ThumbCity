using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionDescriptionSelect : MonoBehaviour
{
    public string[] missionTitle;
    public TMP_Text textMeshProTitle;
    public TMP_Text textMeshProDesc;
    public string[] missionDescription;
    int missionIndex = 0;
    SceneLoad sceneLoad;

    public void nextMission()
    {
        missionIndex = (missionIndex + 1) % missionDescription.Length;
        sceneLoad.startindex = missionIndex+1;

        UpdateMission();
    }
    void Start()
    {
        UpdateMission();
        sceneLoad = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneLoad>();
    }

    // Update is called once per frame
    void UpdateMission()
    {
        textMeshProTitle.text = missionTitle[missionIndex];
        textMeshProDesc.text = missionDescription[missionIndex];
    }
}
