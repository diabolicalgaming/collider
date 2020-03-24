using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Citation -https://www.youtube.com/watch?v=9jejKPPKomg&t=2s
/// This video showed me the steps for how to upload and fecth the data from the DreamLo server.
/// </summary>

public class RankingManager : MonoBehaviour
{
    private const string privateCode = "ItjJkUTArkGHWkNF2QByQQpxlICI7tfE2P3HGaRKVNjA";
    private const string publicCode = "5c8ab5a63eba39041cbfac22";
    private const string webURL = "https://www.dreamlo.com/lb/";

    public Ranking[] rankingList;
    private DisplayRankings display;

    private const string averageKey = "AverageScore";
    public int averageScore = 0;

    private void Awake()
    {
        AddNewScore(PlayerPrefs.GetString("PlayerName"), PlayerPrefs.GetInt("PlayerScore"));
        this.display = GetComponent<DisplayRankings>();
        GetRankings();
    }

    /// <summary>
    /// This function will be called to add the players names and scores to the database when they click the submit button when the game is over.
    /// </summary>
    public void AddNewScore(string name, int score)
    {
        StartCoroutine(UploadScore(name, score));
    }

    /// <summary>
    /// I have written this function to upload the players name and score to the database.
    /// </summary>
    public IEnumerator UploadScore(string name, int score)
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(name) + "/" + score);
        yield return www.SendWebRequest();

        //Check for errors in the upload.
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Succeccfully Uploaded!");
        }
    }

    /// <summary>
    /// This function just pulls the rankings from the database.
    /// </summary>
    public void GetRankings()
    {
        StartCoroutine("DownloadRankingsFromDatabase");
    }

    /// <summary>
    /// I have written this function to download the rankings from the database. It makes a call from my DisplayRankings class
    /// to display the ranking of each player, their name, and score.
    /// </summary>
    public IEnumerator DownloadRankingsFromDatabase()
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
        yield return www.SendWebRequest();

        //Check for errors while retreiving the scores.
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Format(www.downloadHandler.text);
            display.ShowRankings(rankingList);
            this.averageScore = this.rankingList.Sum(r => r.score) / this.rankingList.Length;
        }
        PlayerPrefs.SetInt(averageKey, this.averageScore);
    }

    /// <summary>
    /// This function is derived from the video that I have cited above.
    /// This funcion is used to pull data (player name and scores) from the database and add them to a list
    /// as a list of rankings using my Ranking class.
    /// </summary>
    /// <param name="textStream"> Is the data from the database. </param>
    public void Format(string textStream)
    {
        //RemoveEmptyEntries will remove an new lines that exists and not add the as an entry.
        string[] enteries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        rankingList = new Ranking[enteries.Length];
        for(int i = 0; i < enteries.Length; i++)
        {
            string[] entryInfo = enteries[i].Split(new char[] { '|' });
            string name = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            rankingList[i] = new Ranking(name, score);
        }
    }
}
