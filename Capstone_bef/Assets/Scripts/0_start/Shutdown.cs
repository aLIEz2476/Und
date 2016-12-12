using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutdown : MonoBehaviour {

    public void Exit()
    {
        Invoke("GameShutdown", .3f);
    }

    private void GameShutdown()
    {
        Application.Quit();
    }
}
