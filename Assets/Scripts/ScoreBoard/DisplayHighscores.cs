using System.Collections;
using UnityEngine;

namespace ScoreBoard
{
    // Скрипт из интернета :D
    public class DisplayHighscores : MonoBehaviour 
    {
        [SerializeField] private TMPro.TextMeshProUGUI[] rRanks;
        [SerializeField] private TMPro.TextMeshProUGUI[] rNames;
        [SerializeField] private TMPro.TextMeshProUGUI[] rScores;
        private HighScores _myScores;

        private void Start() //Fetches the Data at the beginning
        {
            _myScores = GetComponent<HighScores>();
            StartCoroutine(RefreshHighscores());
        }
        
        public void SetScoresToMenu(PlayerScore[] highscoreList) // Assigns proper name and score for each text value
        {
            for (var i = 0; i < rNames.Length; i++)
            {
                rRanks[i].text = i + Fields.Scoreboard.RankSeparator + Fields.Scoreboard.IndexationToNumConverter;
                if (highscoreList.Length > i)
                {
                    rScores[i].text = highscoreList[i].Score.ToString();
                    rNames[i].text = highscoreList[i].Username;
                }
                else 
                {
                    rScores[i].text = Fields.Scoreboard.EmptyScore;
                    rNames[i].text = Fields.Scoreboard.EmptyName;
                }
            }
        }

        public void RefreshLeaderboard() => StartCoroutine(RefreshHighscores());
        
        private IEnumerator RefreshHighscores() //Refreshes the scores every call
        {
            for (var i = 0; i < rNames.Length; i++)
            {
                rRanks[i].text = i + Fields.Scoreboard.RankSeparator + Fields.Scoreboard.IndexationToNumConverter;
                rNames[i].text = Fields.Scoreboard.LoadingName;
                rScores[i].text = Fields.Scoreboard.EmptyScore;
            }
            
            _myScores.DownloadScores();
            yield return null;
        }
    }
}