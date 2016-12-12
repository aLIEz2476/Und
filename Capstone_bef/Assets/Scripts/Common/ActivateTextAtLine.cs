using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public NewTextBox_Manager theTextBox;
    public bool requireButtonPress;
    private bool waitForPress;
    public bool destroyWhenActivated;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<NewTextBox_Manager>();

	}
	
	// Update is called once per frame
	void Update () {
        if (waitForPress && Input.GetKeyDown(KeyCode.LeftControl))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            waitForPress = false;

        }
    }
}
