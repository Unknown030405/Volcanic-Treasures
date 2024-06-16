using System;
using System.Collections;
using Player_Scripts;
using UnityEngine;

public class BackgroundMusicMenuScript : MonoBehaviour
{
    private Player _player;
    private AudioSource _source;
    
    private void Start()
    {
        _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();
        _source = GetComponent<AudioSource>();
        _source.volume = 0f;
        
        StartCoroutine(Fade(true, _source, Fields.AudioFade.FadeInLength, Fields.AudioFade.FadeInTargetVolume));
        _player.DeathEvent += DeathFadeOut;
    }

    private void DeathFadeOut(object obj, EventArgs e) => 
        StartCoroutine(Fade(false, _source, Fields.AudioFade.FadeOutLength, Fields.AudioFade.FadeOutTargetVolume));
    
    private void Update()
    {
        if (!_source.isPlaying)
        {
            StartCoroutine(Fade(true, _source, Fields.AudioFade.FadeInLength, Fields.AudioFade.FadeInTargetVolume));
            StartCoroutine(Fade(false, _source, Fields.AudioFade.FadeOutLength, Fields.AudioFade.FadeOutTargetVolume));
        }
    }

    private static IEnumerator Fade(bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        if (!fadeIn)
        {
            var audio = source.clip;
            var lengthSource = (double)audio.samples / audio.frequency;
            yield return new WaitForSecondsRealtime((float)(lengthSource - duration));
        }

        var time = 0f;
        var startVolume = source.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }
    }
}
