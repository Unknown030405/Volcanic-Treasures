using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class DeathLavaScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                other.GetComponent<Player>().Death();
        }
    }
}
