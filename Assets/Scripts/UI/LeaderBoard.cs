using ScoreBoard;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        public void Submit() => HighScores.Instance.UploadScore(inputField.text, PlayerPrefs.GetInt("MaxDistance"));
    }
}
