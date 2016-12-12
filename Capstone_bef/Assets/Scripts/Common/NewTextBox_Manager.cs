using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewTextBox_Manager : MonoBehaviour, IPointerDownHandler {
    [TextArea]
    public GameObject textBox;
    
    public Text text;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public bool IsActive;
    public bool stopPlayerMovement;

    
    public Character_Ctrl player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Character_Ctrl>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
            //Invoke("NextScene", 1f);
        }
        if (IsActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    public void TouchText()
    {
        if (!IsActive)
        {
            return;
        }
        text.text = textLines[currentLine];
        currentLine += 1;

        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }


    }
    public void EnableTextBox()
    {
        textBox.SetActive(true);
        IsActive = true;
        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }
    public void DisableTextBox()
    {
        textBox.SetActive(false);
        IsActive = false;
        player.canMove = true;
        
    }
    void NextScene()
    {
        SceneManager.LoadScene("2_battle");
    }
    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TouchText();
        throw new NotImplementedException();
    }

   
}
