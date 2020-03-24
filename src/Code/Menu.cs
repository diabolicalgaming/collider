using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //whenever we want to change scenes in unity we have to use this

public class Menu : MonoBehaviour {

	public void ClickPlay()
    {
        //whenever we want to change scenes in unity we have to use this
        //this will allow the program to load the next scene in the queue
        //to let me know this works, for now I will add a Debug message
        Debug.Log("Game Opened");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickExit()
    {
        //this will close the game
        //to let me know this works, for now I will add a Debug message
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
