using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class StartSceneView : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button quitButton;

        private void OnEnable()
        {
            startGameButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
