using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Fields;
using Player = Player_Scripts.Player;

namespace UI
{
    public class SubMenu : MonoBehaviour
    {
        [SerializeField] private bool pauseGame;
        [SerializeField] private GameObject pauseGameMenu;
        [SerializeField] private Player player;
        [SerializeField] private TMP_Text totalCoinsText;
        [SerializeField] private TMP_Text totalDiamondsText;
        [SerializeField] private TMP_Text totalDistanceText;

        private void Start() => player.DeathEvent += OnDeathUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnPause(pauseGame);
        }

        public void OnPause(bool isActive)
        {
            pauseGameMenu.SetActive(isActive);
            Time.timeScale = isActive ? Fields.UIBehaviour.PauseTimeScale : Fields.UIBehaviour.ResumeTimeScale;
            pauseGame = !isActive;
        }

        public void LoadScene(string sceneName)
        {
            Time.timeScale = Fields.UIBehaviour.ResumeTimeScale;
            SceneManager.LoadScene(sceneName);
        }
        
        private void OnDeathUI(object sender, EventArgs e)
        {
            Time.timeScale = Fields.UIBehaviour.PauseTimeScale;
            LoadScene("DeathScene");
            totalCoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
            totalDiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();
            totalDistanceText.text = PlayerPrefs.GetInt("Distance").ToString();
        }
    }
}
