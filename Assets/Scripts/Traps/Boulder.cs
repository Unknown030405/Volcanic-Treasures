using System;
using UnityEngine;

namespace Traps
{
    public class Boulder : MonoBehaviour
    {
        [SerializeField] private float gravityForce;
        [SerializeField] private float time;
        [SerializeField] private Rigidbody2D rb;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
            {
                _audioSource.Play();
                rb.gravityScale = gravityForce;
                Destroy(gameObject, time);
            }
        }
    }
}
