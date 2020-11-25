using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ResultPanelView : MonoBehaviour
    {
        [SerializeField] private Text rightScoreText;
        [SerializeField] private Text falseScoreText;
        [SerializeField] private Text congratsText;

        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;

        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartGame);
            menuButton.onClick.AddListener(LoadMainMenu);

            GameManager.OnGameEnded += SetScores;
        }

        private void OnDisable()
        {
            GameManager.OnGameEnded -= SetScores;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(1);
            
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        private void SetScores(int rightScore, int falseScore,string congrats)
        {
            rightScoreText.text = $"RIGHT : {rightScore}";
            falseScoreText.text = $"FALSE : {falseScore}";
            congratsText.text = congrats;
        }

    }
}
