using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using Dan.Models;
using System;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;

    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "980324f10e2f03fc0fd6a38a70f88123919a6aed35a4aea86211ad58b68db9c4";

    public void GetLeaderboard() {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, PlaceLeaderboard);
        Debug.Log("Leaderboard Updated");
    }
    public void SetLeaderboardEntry(string username, int score) {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score,
         (msg) => {
            Debug.Log(msg.ToString());
            GetLeaderboard();
            });
        Debug.Log("Entry Added");
    }

    private void PlaceLeaderboard(Entry[] msg) {
        var length = Math.Min(msg.Length, names.Count);
        for (int i = 0; i < length; i++) {
            names[i].text = msg[i].Username;
            scores[i].text = msg[i].Score.ToString();
        }
    }
}
