using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class Spike : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
                other.GetComponent<Player>().Death();
        }
    }
}
