using System;
using UnityEngine;
using Player = Player_Scripts.Player;

namespace UI
{
    public class SubMenu : SceneLoader
    {
        [SerializeField] private GameObject pauseGameMenu;
        [SerializeField] private Player player;
        private bool _pauseGame = true;

        private void Start() => player.DeathEvent += OnDeathUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnPause(_pauseGame);
        }

        public void OnPause(bool isActive)
        {
            pauseGameMenu.SetActive(isActive);
            Time.timeScale = isActive ? Fields.UIBehaviour.PauseTimeScale : Fields.UIBehaviour.ResumeTimeScale;
            _pauseGame = !isActive;
        }
        
        private void OnDeathUI(object sender, EventArgs e)
        {
            Time.timeScale = Fields.UIBehaviour.PauseTimeScale;
            LoadSceneByName("DeathScene");
        }
    }
}
