using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class StalactiteUp : MonoBehaviour
    {
        [SerializeField] private float gravityScale;
        [SerializeField] private AudioSource audioSource;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
            {
                audioSource.Play();
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
