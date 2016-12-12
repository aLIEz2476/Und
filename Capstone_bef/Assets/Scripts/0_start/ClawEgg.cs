using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClawEgg : MonoBehaviour {

    void Start()
    {
        
    }

    public void Button()
    {
        Invoke("GameStart", .3f);
    }

    private void GameStart()
    {
        SceneManager.LoadScene("1_main");
        //Application.Quit();
    }
    
}
