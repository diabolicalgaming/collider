using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// I have written this class to display the rankings in the Menu scene. When the player clicks the "Ranking" button in the Menu scene
/// they should be able see the top ten player rankings (i.e  ranking of player, name, and their score). This class is responsible
/// for displaying the values pulled from the server.
/// </summary>

public class DisplayRankings : MonoBehaviour
{
    public RankingManager rankingManager;
    public GameObject[] templateObjects;

    // Start is called before the first frame update.
    private void Start()
    {
        DisplayFetching(this.templateObjects);

        rankingManager = GetComponent<RankingManager>();
        StartCoroutine("Refresh");
    }

    /// <summary>
    /// I wrote this function to pull the highscores that were stored in the database and add them to the template objects
    /// in the "Rankings" part of the menu. I have created a Template class that is attached to each template object.
    /// Each template object has a name (player field), score and rank. I pull the data from the database and assign
    /// the correct values that correspond to the template objects.
    /// </summary>
    /// <param name="rankingList"> The list of players that made the top 10. </param>
    //This function will pull the high scores that were stored in the database.
    public void ShowRankings(Ranking[] rankingList)
    {
       for(int i = 0; i < templateObjects.Length; i++)
        {
            //If there are no players in the database, then set the default player name as Not Available and the default score to 0.
            templateObjects[i].GetComponent<Template>().player.GetComponent<Text>().text = "NA";
            templateObjects[i].GetComponent<Template>().score.GetComponent<Text>().text = "0";
            //Sometimes we might have more highscore Texts than we actually have high scores.
            if(i < rankingList.Length)
            {
                templateObjects[i].GetComponent<Template>().player.GetComponent<Text>().text = rankingList[i].name;
                templateObjects[i].GetComponent<Template>().score.GetComponent<Text>().text = rankingList[i].score.ToString();
            }
        }
    }

    /// <summary>
    /// I have written this function to set the player names to "Fetching..." while it retrieing data from the database.
    /// </summary>
    /// <param name="goList"> The list of template objects </param>
    private void DisplayFetching(GameObject[] goList)
    {
        for (int i = 0; i < goList.Length; i++)
        {
            goList[i].GetComponent<Template>().player.GetComponent<Text>().text = "Fetching...";
        }
    }

    /// <summary>
    /// I have written this function to refresh the database every 1 second and to pull the new scores that have been added.
    /// </summary>
    private IEnumerator Refresh()
    {
        while(true)
        {
            rankingManager.GetRankings();
            yield return new WaitForSeconds(1f);
        }
    }
}
