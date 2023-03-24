using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFastestTime : MonoBehaviour
{
    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = PlayerPrefs.GetString("FastestTime", "No Time Recorded");
    }
}
