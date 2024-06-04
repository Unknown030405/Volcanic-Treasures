using System.Collections;
using System.Collections.Generic;
using ScoreBoard;
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
    private bool _muted = false;

    public void SubmitToScoreboard()
    {
        HighScores.Instance.UploadScore(username.text, int.Parse(score.text));
    }

    public void SwitchSound() {
        mixer.SetFloat(Fields.Audio.MasterVolumeName, _muted ? Fields.Audio.NormalVolume : Fields.Audio.MinVolume);
        _muted = !_muted;
    }
}
