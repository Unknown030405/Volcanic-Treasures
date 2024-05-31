using UnityEngine;
using UnityEngine.UI;

namespace Buffs
{
    // Реализация "ботинок"
    public class Boots : LootBuffs
    {
        private const float Acceleration = 1.6f;
        
        public override void AddBuff() => Movement.SetSpeed(Acceleration);

        public override void RemoveBuff() => Movement.ResetSpeed(Acceleration);
        public override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(0);
    }
}