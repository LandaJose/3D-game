using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private bool beginRestart = false;
    public static bool gameIsOver = false;
    public GameObject gameOverUI;
    // Update is called once per frame
    void Update()
    {
        if (beginRestart)
        {
            beginRestart = false;
            DisplayMenu();
        }
    }

    void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsOver = false;
    }

    void DisplayMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsOver = true;
    }

    public void RestartGame()
    {
        EndGame.gameEnded = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsOver = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetBeginRestart()
    {
        beginRestart = true;
    }
}
