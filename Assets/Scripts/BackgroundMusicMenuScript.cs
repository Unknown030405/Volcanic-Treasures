using System;
using System.Collections;
using Player_Scripts;
using UnityEngine;

public class BackgroundMusicMenuScript : MonoBehaviour
{
    private Player _player;
    private AudioSource _source;
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _source = GetComponent<AudioSource>();
        _source.volume = 0f;
        StartCoroutine(Fade(true, _source, 2f, 1f));
        _player.DeathEvent += Bla;
    }

    private void Bla(object obj, EventArgs e)
    {
        StartCoroutine(Fade(false, _source, 2f, 0f));
    }
    
    private void Update()
    {
        if (!_source.isPlaying)
        {
            StartCoroutine(Fade(true, _source, 2f, 1f));
            StartCoroutine(Fade(false, _source, 2f, 0f));
        }
    }

    private IEnumerator Fade(bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        if (!fadeIn)
        {
            var lengthSource = (double)source.clip.samples / source.clip.frequency;
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
