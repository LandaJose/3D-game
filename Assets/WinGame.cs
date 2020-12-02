using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public static bool gameWon = false;
    public GameObject gameWonUI;
    // Update is called once per frame
    void Update()
    {
        if (gameWon)
        {
            DisplayMenu();
        }
    }

    void DisplayMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        gameWonUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameWonUI.SetActive(false);
        Time.timeScale = 1f;
        gameWon = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
