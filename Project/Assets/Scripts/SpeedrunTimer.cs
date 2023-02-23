using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    float timer = 0;

    [SerializeField]
    TMP_Text text;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        int secondFraction = (int)(timer * 100) % 100;
        int seconds = (int)timer;
        int minutes = seconds / 60;
        seconds %= 60;

        text.text = string.Format("{0:00}", minutes) + ":" +
            string.Format("{0:00}", seconds) + ":" +
            string.Format("{0:00}", secondFraction);
    }
}
