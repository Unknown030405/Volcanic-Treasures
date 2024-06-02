using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class FlameThrower : MonoBehaviour
    {
        [SerializeField] private Collider2D fireCollider;

        public void FireOn() => fireCollider.enabled = true;

        public void FireOff() => fireCollider.enabled = false;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
                other.GetComponent<Player>().Death();
        }
    }
}
