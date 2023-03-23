using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    public static SpeedrunTimer instance;

    float timer = 0;
    bool stop = false;
    bool gameOver = false;

    [SerializeField]
    GameObject timerPanel;

    [SerializeField]
    TMP_Text text;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
        if (Input.GetKeyDown(KeyCode.T) && !gameOver)
        {
            stop = !stop;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            timerPanel.SetActive(!timerPanel.active);
        }

    }

    public string GetTime()
    {
        return text.text;
    }

    public void Stop()
    {
        stop = true;
        gameOver = true;
    }
}
