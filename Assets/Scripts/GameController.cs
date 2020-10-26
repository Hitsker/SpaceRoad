using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// Class to control game state, used to pause, resume and restart game
public class GameController : MonoBehaviour
{
    private bool _isPaused;
    private void Start()
    {
        PauseGame();
        GameManager.instance.popUpsContainer.ShowStartPopUp();
    }

    private void Update()
    {
        if (Input.anyKey && _isPaused)
        {
            ResumeGame();
        }
    }
    
    /// <summary>
    /// Pause game by set time scale to 0
    /// </summary>
    private void PauseGame()
    {
        Time.timeScale = 0f;
        _isPaused = true;
    }

    /// <summary>
    /// Unpause game by set time scale to 1
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1;
        _isPaused = false;
    }

    /// <summary>
    /// Loads the first scene in the list of scenes
    /// </summary>
    public static void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
