using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TextAlphaFlash : MonoBehaviour
{
    TMP_Text tMP_Text;

    // Start is called before the first frame update
    void Start()
    {
        tMP_Text = GetComponentInChildren<TMP_Text>();

    }
    bool increaseAlpha = false;
    // Update is called once per frame
    public float rate = 10f;
    void Update()
    {
        if (increaseAlpha)
        {
            if (tMP_Text.alpha < 1f)
            {
                tMP_Text.alpha = tMP_Text.alpha + Time.deltaTime * rate;
            }
            else
            {
                increaseAlpha = false;
            }
        }
        else
        {
            if (tMP_Text.alpha  > 0f)
            {
                tMP_Text.alpha = tMP_Text.alpha - Time.deltaTime * rate;
            }
            else
            {
                increaseAlpha = true;
            }
        }
    }
}
