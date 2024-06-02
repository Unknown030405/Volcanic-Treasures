using UnityEngine;

namespace Traps
{
    public class Gravel : MonoBehaviour
    {
        [SerializeField] private float delay;
        [SerializeField] private Sprite crack;

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Fields.Tags.PlayerTag))
            {
                foreach (var block in gameObject.GetComponentsInChildren<SpriteRenderer>())
                    block.sprite = crack;
                Destroy(gameObject, delay);
            }
        }
    }
}
