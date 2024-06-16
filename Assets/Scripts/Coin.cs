using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Coin : MonoBehaviour, ILootable
{
    [SerializeField] private AudioSource audioSource;
    private Player _player;

    private void Awake() => _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag(Fields.Tags.Chest) && other.CompareTag(Fields.Tags.PlayerTag))
        {
            audioSource.Play();
            _player.AddCoins(Fields.Coins.Min);
            Invoke(nameof(LetsDestroy), Fields.Coins.DestroyTime);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void LetsDestroy() => Destroy(gameObject);

    public void GivePlayer()
    {
        var coin = Random.Range(Fields.Coins.Min, Fields.Coins.Max);
        _player.AddCoins(coin);
    }
}