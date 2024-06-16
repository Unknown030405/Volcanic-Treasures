using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        public event EventHandler DeathEvent;
        
        public Dictionary<Transform, float> Effects { get; } = new();
        public Key Key { get; set; }
        public int Coins { get; private set; }
        public int Diamonds { get; private set; }
        public bool HasHelmet { get; set; }
        public bool HasRingLava { get; set; }
        
        private float _playerDistance;
        private float _maxPlayerDistance;
        
        public void AddCoins(int coinsAmount) => Coins += coinsAmount;
        public void AddDiamonds(int diamondsAmount) => Diamonds += diamondsAmount;

        private void Update()
        {
            var blockSpeed = Fields.Generation.BlockBaseSpeed + Time.timeSinceLevelLoad * 
                Fields.Generation.BlockSpeedIncrease;
            _playerDistance += blockSpeed * Time.deltaTime;
            _maxPlayerDistance = Math.Max(_playerDistance + transform.position.y, _maxPlayerDistance);
        }

        public int GetPlayerDistance() => (int)_maxPlayerDistance;
        
        public void Death()
        {
            // Посчитать текущий счёт
            var score = (int)_maxPlayerDistance + Fields.Score.CoinMultiplier * Coins +
                        Fields.Score.DiamondMultiplier * Diamonds;
            
            PlayerPrefs.SetInt(Fields.SaveSystem.PlayerCoins, Coins);
            PlayerPrefs.SetInt(Fields.SaveSystem.PlayerDiamonds, Diamonds);
            PlayerPrefs.SetInt(Fields.SaveSystem.Distance, score);
            PlayerPrefs.SetInt(Fields.SaveSystem.MaxDistance, Math.Max(score, 
                PlayerPrefs.GetInt(Fields.SaveSystem.MaxDistance)));
            
            // Вызов ивента смерти
            DeathEvent?.Invoke(this, EventArgs.Empty);
            gameObject.GetComponent<Movement>().Freeze();
        }
    }
}
