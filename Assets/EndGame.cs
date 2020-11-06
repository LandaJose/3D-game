using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static Boolean gameEnded = false;
    public void EndedGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Restart();
        }
    }

    private void Restart()
    {
        FindObjectOfType<GameOverMenu>().SetBeginRestart();
    }
}
