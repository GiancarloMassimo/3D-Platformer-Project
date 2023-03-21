using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;

    public GameObject textDisplay;
    public TMP_Text text;
    public string[] content;
    public float tSpeed;
    public float endDelay;
    private int index = -1;

    private string[] dialogueTriggrTest =
    {
        "Hello",
        "This is a",
        "Test"
    };

    bool finishedContent = false;

    bool playingDialogue = false;

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
        NextSentence();

        if (Input.GetKeyDown(KeyCode.P))
        {
            TriggerDialogue(dialogueTriggrTest);
        }
    }
    IEnumerator Type()
    {
        textDisplay.SetActive(true);
        foreach (char letter in content[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(tSpeed);
        }
        yield return new WaitForSeconds(endDelay);
        text.text = "";
        textDisplay.SetActive(false);
        playingDialogue = false;

        if (index == content.Length - 1)
        {
            finishedContent = true;
        }
    }

    public void NextSentence()
    {
        if (Input.GetKeyDown(KeyCode.E) && index < content.Length - 1 && !playingDialogue) 
        {
            index++;
            text.text = "";
            playingDialogue = true;
            StartCoroutine(Type());
        }
    }

    public void TriggerDialogue(string[] dialogue)
    {
        if (!finishedContent)
        {
            return;
        }

        content = dialogue;
        finishedContent = true;
        index = -1;
        NextSentence();
    }
}


