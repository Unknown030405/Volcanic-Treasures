using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour 
{
    [SerializeField] private TMPro.TextMeshProUGUI[] rRanks;
    [SerializeField] private TMPro.TextMeshProUGUI[] rNames;
    [SerializeField] private TMPro.TextMeshProUGUI[] rScores;
    private HighScores myScores;

    void Start() //Fetches the Data at the beginning
    {
        myScores = GetComponent<HighScores>();
        StartCoroutine(RefreshHighscores());
    }
    public void SetScoresToMenu(PlayerScore[] highscoreList) // Assigns proper name and score for each text value
    {
        for (var i = 0; i < rNames.Length; i++)
        {
            rRanks[i].text = i + 1 + Fields.Scoreboard.RankSeparator;
            if (highscoreList.Length > i)
            {
                rScores[i].text = highscoreList[i].score.ToString();
                rNames[i].text = highscoreList[i].username;
            }
            else {
                rScores[i].text = Fields.Scoreboard.EmptyScore;
                rNames[i].text = Fields.Scoreboard.EmptyName;
            }
        }
    }

    public void RefreshLeaderboard() 
    {
        StartCoroutine(RefreshHighscores());
    }
    private IEnumerator RefreshHighscores() //Refreshes the scores every call
    {
        for (var i = 0; i < rNames.Length; i++)
        {
            rRanks[i].text = i + 1 + Fields.Scoreboard.RankSeparator;
            rNames[i].text = Fields.Scoreboard.LoadingName;
            rScores[i].text = Fields.Scoreboard.EmptyScore;
        }
        myScores.DownloadScores();
        yield return null;
    }
}
