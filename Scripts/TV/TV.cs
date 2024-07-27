using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TV : MonoBehaviour
{
    public string[] strings;
    TMP_Text tMP_Text;

    // Start is called before the first frame update
    void Start()
    {
        tMP_Text = GetComponentInChildren<TMP_Text>();
        lastChange = Time.time;
        tMP_Text.text = strings[0];
    }
    float lastChange;
    public float changeTime;
    int index;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastChange + changeTime)
        {
            index = (index + 1) % strings.Length;
            tMP_Text.text = strings[index];
            lastChange = Time.time;
        }
    }
}
