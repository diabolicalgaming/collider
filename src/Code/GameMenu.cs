using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// I have written this class to display an in-game pause menu to the player when they click the escape button.
/// </summary>

public class GameMenu : MonoBehaviour
{
    [HideInInspector]public static bool Paused { get; set; }
    private KeyCode pauseKey;
    public GameObject gameMenuUI;

    //Awake to act as a constructor
    private void Awake()
    {
        //When the player first enters the game, it shouldn't be paused.
        Paused = false;

        //Escape to pause the game.
        this.pauseKey = KeyCode.Escape;
    }

    // Update is called once per frame
    private void Update()
    {
        //Whenever the player presses escape, the game state is updated and the player menu is loaded.
        PausedGame();
    }

    /// <summary>
    /// I have written this function which will be attached to the "Resume" button for the in-game menu.
    /// When the player clicks the resume button certain actions should take place...
    /// </summary>
    public void Resume()
    {
        //Start playing the background music again.
        FindObjectOfType<SoundManager>().Play("BackgroundMusic");
        //When the player clicks the resume button in the pause menu, the pause menu is closed.
        gameMenuUI.SetActive(false);

        //Time goes back to normal, and the player continues to play.
        Time.timeScale = 1f;

        //Unpause the game.
        Paused = false;
    }

    /// <summary>
    /// I have written this function, which is called when the user pauses the game.
    /// </summary>
    public void Pause()
    {
        //Pause the background music.
        FindObjectOfType<SoundManager>().PauseBGM("BackgroundMusic");
        //When the player pauses the game allow them to see the pause menu.
        gameMenuUI.SetActive(true);

        //Freeze time so that the game objects in the game stop moving.
        Time.timeScale = 0f;

        //Pause the game.
        Paused = true;
    }

    public void Menu()
    {
        //If the player goes back to the menu, then the game should not be paused, so set the time back to normal.
        Time.timeScale = 1f;

        //Load the main menu.
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// I have written this function, which will check when the player clicks the escape button.
    /// </summary>
    private void PausedGame()
    {
        if(Input.GetKeyDown(this.pauseKey) && !FindObjectOfType<GameManager>().gameIsOver)
        {
            //if the game is not paused, then when you press escape the game will be paused
            if (!Paused)
            {
                Pause();
            }
            //if the game is paused then the player has already pressed escape, so allow them to resume the game
            else if (Paused)
            {
                Resume();
            }
        }
    }
}
