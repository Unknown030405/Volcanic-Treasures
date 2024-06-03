using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubmitLeaders : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI username;
    [SerializeField]
    private TextMeshProUGUI score;

    public void SubmitToScoreboard()
    {
        HighScores.instance.UploadScore(username.text, int.Parse(score.text));
    }
}
