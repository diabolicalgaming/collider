using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

/// <summary>
/// I have written this class to hold the players name and score.
/// </summary>
public class PlayerScore : MonoBehaviour
{
    public string PlayerName {get; set;}
    public int Score { get; set; } 
    private Text scoreText;
    public InputField nameInput;
    public Button submitButton;

    //These are the keys that will be used in the PlayerPrefs. Explained on line 51.
    private const string nameKey = "PlayerName";
    private const string scoreKey = "PlayerScore";

    //Awake to act as a constructor
    private void Awake()
    {
        this.PlayerName = PlayerName;
        this.Score = Score;
        this.submitButton.GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        //update the score whenver the player hits an enemy
        this.Score = int.Parse(UpdateScore().text);
        ValidateLength();
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.scoreText = GetComponent<Text>();
    }

    private Text UpdateScore()
    {
        this.scoreText.text = this.Score.ToString("D9");
        return scoreText;
    }

    /// <summary>
    /// Here I wrote a function that will be attached to the submit button in the UI.
    /// Here I make a call to Unity's PlayerPrefs class. PlayerPrefs are used to store
    /// and access player preferences between game sessions. It is like a dictionary and uses key value pairs.
    /// This will allow me to get the players name and score for any game session and add them to the database in the Rankings class.
    /// </summary>
    public void OnSubmit()
    {
        this.PlayerName = this.nameInput.text;
        PlayerPrefs.SetString(nameKey,this.PlayerName);
        PlayerPrefs.SetInt(scoreKey, this.Score);
        Debug.Log("Your name is " + PlayerName);
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// I have written this function to check if the player has input a name and that it is at least three characters
    /// long before they can click the submit button.
    /// </summary>
    private void ValidateLength()
    {
        //Regular expression to ensure that names are only alphanumeric characters.
        Regex regex = new Regex("^[a-zA-Z0-9]*$");
        if(this.nameInput.text.Length >= 3 && this.nameInput.text.Length <= 10 && regex.IsMatch(this.nameInput.text))
        {
            this.submitButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.submitButton.GetComponent<Button>().interactable = false;
        }
    }
}
