using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    float timer = 0;
    bool stop = false;

    [SerializeField]
    TMP_Text text;

    void Start()
    {
        
    }

    void Update()
    {
        if (!stop) 
            timer += Time.deltaTime;

        int secondFraction = (int)(timer * 100) % 100;
        int seconds = (int)timer;
        int minutes = seconds / 60;
        seconds %= 60;

        text.text = string.Format("{0:00}", minutes) + ":" +
            string.Format("{0:00}", seconds) + ":" +
            string.Format("{0:00}", secondFraction);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            stop = !stop;
        }

    }
}
