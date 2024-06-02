using Player_Scripts;
using UnityEngine;

namespace Buffs
{
    // Скрипт описывает логику эффекта (объекта) "Dirt"
    public class Dirt : Buffs
    {
        [SerializeField] private GameObject player;
        
        private Movement _movement;

        protected override void AddBuff()
        {
            _movement = player.GetComponent<Movement>();
            _movement.SetSpeed(Fields.Buffs.DirtSlowdown);
            _movement.SetJumpForce(Fields.Buffs.DirtSlowdown);
        }

        protected override void RemoveBuff()
        {
            _movement.ResetSpeed(Fields.Buffs.DirtSlowdown);
            _movement.ResetJumpForce(Fields.Buffs.DirtSlowdown);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
                AddBuff();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag))
                RemoveBuff();
        }
    }
}
