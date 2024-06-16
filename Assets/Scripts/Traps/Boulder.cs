using UnityEngine;

namespace Traps
{
    public class Boulder : MonoBehaviour
    {
        [SerializeField] private float gravityForce;
        [SerializeField] private float time;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private AudioSource audioSource;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
            {
                audioSource.Play();
                rb.gravityScale = gravityForce;
                Destroy(gameObject, time);
            }
        }
    }
}
