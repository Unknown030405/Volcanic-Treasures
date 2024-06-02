using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Coin : MonoBehaviour, ILootable
{
    private Player _player;
    
    private void Awake() => _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag(Fields.Tags.Chest) && other.CompareTag(Fields.Tags.PlayerTag))
        {
            _player.AddCoins(Fields.Coins.Min);
            Destroy(gameObject);
            Debug.Log("Coin claimed");
        }
    }

    public void GivePlayer()
    {
        var coin = Random.Range(Fields.Coins.Min, Fields.Coins.Max);
        _player.AddCoins(coin);
        Debug.Log($"Coin from chest claimed : {coin}");
    }
}