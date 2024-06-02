using System.Collections.Generic;
using Buffs;
using Interfaces;
using Player_Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    private List<ILootable> _loot;

    private void Awake()
    {
        // Инициализация списка выпадаемых предметов из сундука
        _loot = new()
        {
            gameObject.AddComponent<Boots>(),
            gameObject.AddComponent<Helmet>(),
            gameObject.AddComponent<LavaRing>(),
            gameObject.AddComponent<Coin>(),
            gameObject.AddComponent<Diamond>()
        };
        
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка на то, что игрок контактирует с сундуком
        if (other.CompareTag(Fields.Tags.PlayerTag))
        {
            //Проверка на то, что у игрока есть подходящий ключ
            var key = other.gameObject.GetComponent<Player>().Key;
            if (key && key.CompareTag(Fields.Tags.ChestKey))
            {
                _animator.Play(Fields.AnimationState.Chest);
                key.Rigidbody.velocity = new Vector2(0, 0);
                Destroy(key.gameObject);
                DropItem();
            }
        }
    }

    // Выдать игроку предмет
    private void DropItem()
    {
        var dropped = _loot[Random.Range(0, _loot.Count)];
        dropped.GivePlayer();
    }
}
