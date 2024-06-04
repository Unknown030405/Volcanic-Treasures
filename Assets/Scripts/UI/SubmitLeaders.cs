using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SubmitLeaders : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI username;
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private AudioMixer mixer;
    private bool muted = false;

    public void SubmitToScoreboard()
    {
        HighScores.instance.UploadScore(username.text, int.Parse(score.text));
    }

    public void SwitchSound() {
        Debug.Log(mixer.SetFloat("Master", muted ? -4f : -80f));
    }
}
