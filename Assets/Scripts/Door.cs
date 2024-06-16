using Player_Scripts;
using UnityEngine;

// Данный скрипт весит на оюъекте "Door" и позволяет производить манипуляции с нею
public class Door : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Проверка на то, что игрок контактирует с дверью
        if (other.collider.CompareTag(Fields.Tags.PlayerTag))
        {
            // Проверка на то, что у игрока есть подходящий ключ
            var key = other.gameObject.GetComponent<Player>().Key;
            if (key && key.CompareTag(Fields.Tags.DoorKey))
            {
                key.Rigidbody.velocity = Vector2.zero;
                animator.Play(Fields.AnimationState.Door);
                Destroy(key.gameObject);
                audioSource.Play();
                Invoke(nameof(ChangeTriggerState), Fields.DoorOpenTime);
            }
        }
    }
    
    private void ChangeTriggerState() => col.isTrigger = true;
}
