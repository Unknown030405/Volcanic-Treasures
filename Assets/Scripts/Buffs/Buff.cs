using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Buffs
{
    public abstract class Buffs : MonoBehaviour
    {
        protected Player Player;
        protected Movement Movement;
        protected Canvas Canvas;
        
        private void Awake()
        {
            var player = GameObject.FindWithTag(Fields.Tags.PlayerTag);
            Canvas = GameObject.FindWithTag(Fields.Tags.Canvas).GetComponent<Canvas>();
            Player = player.GetComponent<Player>();
            Movement = player.GetComponent<Movement>();
        }
        
        protected abstract void AddBuff();

        protected abstract void RemoveBuff();
    }
    
    // Данный класс отвечает за все эффекты игрока, которые можно подобрать из сундука
    public abstract class LootBuffs : Buffs, ILootable
    {
        protected abstract Transform GetImage();

        public void GivePlayer()
        {
            AddBuff();

            if (Player.Effects.ContainsKey(GetImage()))
                Player.Effects[GetImage()] = Fields.Buffs.UsingTime;
            else
                Player.Effects.Add(GetImage(), Fields.Buffs.UsingTime);
            Debug.Log("Item Given");

            Invoke(nameof(RemoveBuff), Fields.Buffs.UsingTime);
        }
    }
}