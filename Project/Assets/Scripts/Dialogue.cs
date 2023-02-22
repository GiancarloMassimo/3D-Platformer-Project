using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    public GameObject textDisplay;
    public TMP_Text text;
    public string[] content;
    public float tSpeed;
    public float endDelay;
    private int index = -1;

    bool playingDialogue = false;

    void Update()
    {
        NextSentence();
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
}


