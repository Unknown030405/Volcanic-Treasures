using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            // Загружаем стартовую сцену
            SceneManager.LoadScene(Fields.Scenes.Block1);
        }

        public void ExitGame()
        {
            Debug.Log("Game quit");
            Application.Quit();
        }
    }
}
