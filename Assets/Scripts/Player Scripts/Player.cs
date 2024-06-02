using System;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Internal;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        public int TotalCoins { get; set; }
        public int TotalDiamonds { get; set; }
        // private string _coinsKey = "CoinsKey";
        // private string _diamondsKey = "DiamondsKey";
        
        public int Coins { get; private set; }
        public int Diamonds { get; private set; }
        public bool HasHelmet { get; set; }
        public bool HasRingLava { get; set; }
        public Key Key { get; set; }
        public Dictionary<Transform, float> Effects { get; } = new();

        public void AddCoins(int coinsAmount) => Coins += coinsAmount;
        public void AddDiamonds(int diamondsAmount) => Diamonds += diamondsAmount;

        public void Death()
        {
            gameObject.SetActive(false);
        }

    }
}
