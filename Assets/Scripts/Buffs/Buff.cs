using System;
using Interfaces;
using JetBrains.Annotations;
using Player_Scripts;
using UI;
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
            var image = GetImage();
            if (Player.Effects.ContainsKey(image))
                Player.Effects[image] = Fields.Buffs.UsingTime;
            else
            {
                Player.Effects.Add(image, Fields.Buffs.UsingTime);
                // Player.CreateBuffEvent(this, new UIEventArgs(image));
            }
            Debug.Log("Item Given");

            Invoke(nameof(RemoveBuff), Fields.Buffs.UsingTime);
        }
    }
}