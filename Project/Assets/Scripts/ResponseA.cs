using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ResponseA : MonoBehaviour
{

    public GameObject textDisplay;
    public TMP_Text text;
    public string[] content;
    public float tSpeed;
    private int index = -1;

    private string[] dialogueTriggrTest =
    {
        "Hello",
        "This is a",
        "Test"
    };

    bool finishedContent = false;

    bool playingDialogue = false;

  

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
            textDisplay.SetActive(false);
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



