using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace ScoreBoard
{
    // Скрипт из интернета :D
    public class HighScores : MonoBehaviour
    {
        private PlayerScore[] _scoreList;
        private DisplayHighscores _myDisplay;
        public static HighScores Instance;
        
        private delegate void RequestAnswerCallback(string message);

        private void Awake()
        {
            Instance = this; //Sets Static Instance
            _myDisplay = GetComponent<DisplayHighscores>();
        }
        
        private IEnumerator SendDatabaseRequest(string uri, RequestAnswerCallback callback)
        {
            var request = UnityWebRequest.Get(Fields.Scoreboard.WebURL + uri);
            yield return request.SendWebRequest();

            var pages = uri.Split('/');
            var page = pages.Length - 1;

            switch (request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + Fields.Requests.DefaultErrorMessage + request.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + Fields.Requests.ProtocolErrorMessage + request.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + Fields.Requests.SuccessMessage + request.downloadHandler.text);
                    callback(request.downloadHandler.text);
                    break;
            }
        }
        
        public void UploadScore(string username, int score)
        {
            // form an uri without webURL
            var uri = Fields.Scoreboard.PrivateCode + Fields.Requests.AddRequest + username + 
                      Fields.Requests.QuerySeparator + score;
            StartCoroutine(SendDatabaseRequest(uri, _ => {DownloadScores();}));
        }
    
        public void DownloadScores(int amount = 10)
        {
            var uri = Fields.Scoreboard.PublicCode + Fields.Requests.GetFromStartRequest + amount;
            StartCoroutine(SendDatabaseRequest(uri, DownloadCallback));
        }
        
        private void DownloadCallback(string message) 
        {
            OrganizeInfo(message);
            _myDisplay.SetScoresToMenu(_scoreList);
        }

        // Divides Scoreboard info into scoreList
        private void OrganizeInfo(string rawData)
        {
            var entries = rawData.Split(Fields.Requests.LineSeparator, 
                System.StringSplitOptions.RemoveEmptyEntries); // get all entries
            
            _scoreList = new PlayerScore[entries.Length];
            for (var i = 0; i < entries.Length; i++)
                _scoreList[i] = ParseEntry(entries[i]);
        }
        
        private PlayerScore ParseEntry(string dbEntry)
        {
            var entryInfo = dbEntry.Split(Fields.Requests.EntrySeparator);
            var username = entryInfo[Fields.Requests.UserNameIndex];
            var score = int.Parse(entryInfo[Fields.Requests.ScoreIndex]);
            return new PlayerScore(username, score);
        }
    }

    public struct PlayerScore
    {
        public readonly string Username;
        public readonly int Score;

        public PlayerScore(string username, int score)
        {
            Username = username;
            Score = score;
        }
    }
}