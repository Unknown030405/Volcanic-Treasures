using UnityEngine;

namespace Buffs
{
    // Реализация "шлема"
    public class Helmet : LootBuffs
    {
        protected override void AddBuff() => Player.HasHelmet = true;

        protected override void RemoveBuff() => Player.HasHelmet = false;
        
        protected override Transform GetTransform() => 
            Canvas.transform.GetChild(Fields.Buffs.PanelIndex).GetChild(Fields.Buffs.HelmetIconIndex);
    }
}