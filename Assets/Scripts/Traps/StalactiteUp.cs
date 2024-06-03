using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class StalactiteUp : MonoBehaviour
    {
        [SerializeField] private float gravityScale;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
            {
                _audioSource.Play();
                GetComponent<Rigidbody2D>().gravityScale = gravityScale;
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.collider.CompareTag(Fields.Tags.PlayerTag))
            {
                var player = other.gameObject.GetComponent<Player>();
                if (!player.HasHelmet)
                    other.gameObject.GetComponent<Player>().Death();
            }
            Destroy(gameObject);
        }
    }
}
