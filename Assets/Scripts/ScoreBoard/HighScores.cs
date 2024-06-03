using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour
{
    private PlayerScore[] scoreList;
    private DisplayHighscores myDisplay;

    public static HighScores instance;
    private delegate void RequestAnswerCallback(string message);
    public delegate void DatabaseAnswerCallback(PlayerScore playerScore);

    private void Awake()
    {
        instance = this; //Sets Static Instance
        myDisplay = GetComponent<DisplayHighscores>();
    }
    private IEnumerator SendDatabaseRequest(string uri, RequestAnswerCallback callback)
    {
        var request = UnityWebRequest.Get(Fields.Scoreboard.webURL + uri);
        yield return request.SendWebRequest();

        string[] pages = uri.Split('/');
        int page = pages.Length - 1;

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
        var uri = Fields.Scoreboard.privateCode + Fields.Requests.AddRequest + username + Fields.Requests.QuerrySeparator + score;
        StartCoroutine(SendDatabaseRequest(uri, (string _) => {DownloadScores();}));
    }
    
    public void DownloadScores(int amount = 10)
    {
        var uri = Fields.Scoreboard.publicCode + Fields.Requests.GetFromStartRequest + amount.ToString();
        StartCoroutine(SendDatabaseRequest(uri, DownloadCallback));
    }
    private void DownloadCallback(string message) {
        OrganizeInfo(message);
        myDisplay.SetScoresToMenu(scoreList);
    }

    public void GetPlayerScoreByName(string username, DatabaseAnswerCallback callback) {
        var uri = Fields.Scoreboard.publicCode + Fields.Requests.GetByNameRequest + username;
        StartCoroutine(SendDatabaseRequest(uri, (string msg) => {callback(ParseEntry(msg));}));
    }

    // // Divides Scoreboard info into scoreList
    private void OrganizeInfo(string rawData)
    {
        var entries = rawData.Split(Fields.Requests.LineSeparator, System.StringSplitOptions.RemoveEmptyEntries); // get all entries
        scoreList = new PlayerScore[entries.Length];
        for (var i = 0; i < entries.Length; i++)
        {
            scoreList[i] = ParseEntry(entries[i]);
        }
    }
    private PlayerScore ParseEntry(string dbEntry)
    {
        var entryInfo = dbEntry.Split(Fields.Requests.EntrySeparator);
        var username = entryInfo[0];
        var score = int.Parse(entryInfo[1]);
        return new PlayerScore(username, score);
    }
}

public struct PlayerScore
{
    public string username;
    public int score;

    public PlayerScore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}