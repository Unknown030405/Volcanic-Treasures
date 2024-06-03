using System;
using System.Collections.Generic;
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
        private float PlayerDistance { get; set; }
        private float MaxPlayerDistance { get; set; }
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
            var blockSpeed = 
                Fields.Generation.BlockBaseSpeed + Time.timeSinceLevelLoad * Fields.Generation.BlockSpeedIncrease;
            PlayerDistance += blockSpeed * Time.deltaTime;
            MaxPlayerDistance = Math.Max(PlayerDistance + transform.position.y, MaxPlayerDistance);
            // Debug.Log(Distance);
        }

        public int GetPlayerDistance() => (int)MaxPlayerDistance;

        // public void CreateBuffEvent(object obj, UIEventArgs args)
        // {
        //     BuffEvent?.Invoke(obj, args);
        // }
        
        public void Death()
        {
            PlayerPrefs.SetInt("Coins", Coins);
            PlayerPrefs.SetInt("Diamonds", Diamonds);
            PlayerPrefs.SetInt("Distance", (int)MaxPlayerDistance * Coins);
            PlayerPrefs.SetInt("MaxDistance", Math.Max((int)MaxPlayerDistance * Coins, PlayerPrefs.GetInt("MaxDistance")));
            DeathEvent?.Invoke(this, EventArgs.Empty);
            gameObject.GetComponent<Movement>().Freeze();
        }
    }
}
