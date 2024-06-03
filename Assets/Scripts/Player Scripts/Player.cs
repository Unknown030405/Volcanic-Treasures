using System;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        public event EventHandler DeathEvent;
        // public event EventHandler BuffEvent;
        public int TotalCoins { get; set; }
        public int TotalDiamonds { get; set; }
        public int TotalDistance { get; set; }
        
        public int Coins { get; private set; }
        public int Diamonds { get; private set; }
        public float Distance { get; set; }
        public bool HasHelmet { get; set; }
        public bool HasRingLava { get; set; }
        public Key Key { get; set; }
        public Dictionary<Transform, float> Effects { get; } = new();

        private void Awake()
        {
            TotalCoins = PlayerPrefs.GetInt("Coins", 0);
            TotalDiamonds = PlayerPrefs.GetInt("Diamonds", 0);
            TotalDistance = PlayerPrefs.GetInt("Distance", 0);
        }

        public void AddCoins(int coinsAmount) => Coins += coinsAmount;
        public void AddDiamonds(int diamondsAmount) => Diamonds += diamondsAmount;

        private void Update()
        {
            UpdateDistance();
            // Debug.Log(Distance);
        }

        public void UpdateDistance()
        {
            Distance += Fields.Generation.BlockBaseSpeed;
        }

        // public void CreateBuffEvent(object obj, UIEventArgs args)
        // {
        //     BuffEvent?.Invoke(obj, args);
        // }
        
        public void Death()
        {
            DeathEvent?.Invoke(this, EventArgs.Empty);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Coins);
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + Diamonds);
            PlayerPrefs.SetInt("Distance", (int)Distance);
        }
    }
}
