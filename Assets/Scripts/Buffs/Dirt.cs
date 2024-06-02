using UnityEngine;

namespace Buffs
{
    // Скрипт описывает логику эффекта (объекта) "Dirt"
    public class Dirt : Buffs
    {
        protected override void AddBuff()
        {
            Movement.SetSpeed(Fields.Buffs.DirtSlowdown);
            Movement.SetJumpForce(Fields.Buffs.DirtSlowdown);
        }

        protected override void RemoveBuff()
        {
            Movement.ResetSpeed(Fields.Buffs.DirtSlowdown);
            Movement.ResetJumpForce(Fields.Buffs.DirtSlowdown);
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
