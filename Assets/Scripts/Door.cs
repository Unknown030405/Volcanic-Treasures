using Player_Scripts;
using UnityEngine;

// Данный скрипт весит на оюъекте "Door" и позволяет производить манипуляции с нею
public class Door : MonoBehaviour
{
    private Collider2D _collider2D;
    private Animator _animator;
    private AudioSource _audioSource;
    
    private void Awake()
    { 
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Проверка на то, что игрок контактирует с дверью
        if (other.collider.CompareTag(Fields.Tags.PlayerTag))
        {
            // Проверка на то, что у игрока есть подходящий ключ
            var key = other.gameObject.GetComponent<Player>().Key;
            if (key && key.CompareTag(Fields.Tags.DoorKey))
            {
                key.Rigidbody.velocity = new Vector2(0, 0);
                _animator.Play(Fields.AnimationState.Door);
                Destroy(key.gameObject);
                _audioSource.Play();
                Invoke(nameof(ChangeTriggerState), Fields.DoorOpenTime);
            }
        }
    }
    
    private void ChangeTriggerState() => _collider2D.isTrigger = true;
}
