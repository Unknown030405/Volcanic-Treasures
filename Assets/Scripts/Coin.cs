using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;

public class Coin : MonoBehaviour, ILootable
{
    private Player _player;
    private AudioSource _audioSource;

    private void Awake()
    {
        _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag(Fields.Tags.Chest) && other.CompareTag(Fields.Tags.PlayerTag))
        {
            _audioSource.Play();
            _player.AddCoins(Fields.Coins.Min);
            Invoke(nameof(LetsDestroy), 1f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Debug.Log("Coin claimed");
        }
    }

    private void LetsDestroy() => Destroy(gameObject);

    public void GivePlayer()
    {
        var coin = Random.Range(Fields.Coins.Min, Fields.Coins.Max);
        _player.AddCoins(coin);
        Debug.Log($"Coin from chest claimed : {coin}");
    }
}