using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitles : MonoBehaviour
{
    private TMP_Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    private bool invisibleCharacters;
    private float displayTime;

    public void AddWriter(TMP_Text text, string toWrite, float time, bool invisChar, float disTime)
    {
        uiText = text;
        textToWrite = toWrite;
        timePerCharacter = time;
        invisibleCharacters = invisChar;
        characterIndex = 0;
        displayTime = disTime;

        if (displayTime != -1)
        {
            StartCoroutine(TurnOffDisplay(uiText, displayTime));
        }
    }

    private void Update()
    {
        if (uiText)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;

                if (textToWrite.Length <= 0)
                {
                    uiText = null;
                    return;
                }
                else
                {
                    string text = textToWrite.Substring(0, characterIndex);
                    if (invisibleCharacters)
                    {
                        text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                    }
                    uiText.text = text;

                    if (characterIndex >= textToWrite.Length)
                    {
                        uiText = null;
                        return;
                    }
                }
            }
        }
    }

    private IEnumerator TurnOffDisplay(TMP_Text text, float displayTime)
    {
        yield return new WaitForSeconds(displayTime);
        text.text = "";
    }
}
