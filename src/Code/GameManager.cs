using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// I have created this class to control the state of the game. When the player loses they will have the option to either
/// play again or leave the game and submit their name and score (which will be posted to the Ranking Database).
/// Note, the GameManager class is not provided by the Unity API.
/// </summary>

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// I will need references to the Game Over components, enemy spawner, boss spawner, and collectable spawner.
    /// </summary>
    public GameObject gameOver;
    public GameObject spawnManager;

    public bool gameIsOver = false;

    /// <summary>
    /// I have written this function to perform the specified actions when the game is over.
    /// When the game is over, certain events should take place.
    /// Objects attached to the SpawnManager components should be stopped.
    /// Display the Game Over Object. 
    /// Allow the player to decide if they want to play again (this is also a component of the Game Over object).
    /// The background music should stop playing.
    /// The game over audio should play only once.
    /// The battle music should start playing (battle music is just the title on the audio).
    /// If the player clicks no, display the input option to allow the player to enter their name.
    /// </summary>
    public void GameOver()
    {
        this.gameIsOver = true;
        if(this.spawnManager != null)
        {
            this.spawnManager.GetComponent<SpawnManager>().StopSpawning();
            StartCoroutine(DisableObject(this.spawnManager, 1f));
        }

        StartCoroutine(ShowObject(gameOver, 1f));
        FindObjectOfType<SoundManager>().StopBGM("BackgroundMusic");
        FindObjectOfType<SoundManager>().PlayOnce("GameOver");
        FindObjectOfType<SoundManager>().Play("BattleMusic");
    }

    /// <summary>
    /// I have written this function which will be attached to the "Yes" button when the game is over.
    /// If the player clicks yes, it reloads the scene and the players starts again with a score of 0.
    /// </summary>
    public void PlayAgain()
    {
        //Reload the scene that the player is currently in.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<SoundManager>().StopBGM("BattleMusic");
    }

    /// <summary>
    /// I have written this function to allow me to set a specific game object to true after a particular time interval.
    /// </summary>
    /// <param name="go"> The game object that you want to enable in the UI. </param>
    /// <param name="time"> The time that you want to enable this object. </param>
    /// <returns> Waits for a specified number of seconds and then enables the corresponding game object. </returns>
    public IEnumerator ShowObject(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(true);
    }

    /// <summary>
    /// I have written this function to allow me to disable a specific game obect after a particular time interval.
    /// </summary>
    /// <param name="go"> The game object in the UI that you want to disable. </param>
    /// <param name="time"> The time that you want to disable this object. </param>
    /// <returns> Waits for a specified number of seconds and then disables the corresponding game object. </returns>
    public IEnumerator DisableObject(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(false);
    }
}
