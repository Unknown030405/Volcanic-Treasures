using UnityEngine;

namespace Buffs
{
    // Реализация "защиты"
    public class LavaRing : LootBuffs
    {
        protected override void AddBuff() => Player.HasRingLava = true;

        protected override void RemoveBuff() => Player.HasRingLava = false;
        
        protected override Transform GetTransform() => 
            Canvas.transform.GetChild(Fields.Buffs.PanelIndex).GetChild(Fields.Buffs.LavaRingIconIndex);
    }
}