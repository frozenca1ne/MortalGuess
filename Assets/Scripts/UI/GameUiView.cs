using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUiView : MonoBehaviour
    {
        public static event Action OnHintUsed;
    
        [SerializeField] private Button useHelpButton;

        [Header("Score")] 
        [SerializeField] private Text trueScoreText;
        [SerializeField] private Text falseScoreText;
        [SerializeField] private Image[] livesImages;
    
        private void OnEnable()
        {
            useHelpButton.onClick.AddListener(UseHint);
            GameManager.OnTrueAnswerChanged += SetCurrentRightScore;
            GameManager.OnFalseAnswerChanged += SetCurrentFalseScore;
            GameManager.OnHealthChanged += SetCurrentHealthCount;
        }

        private void OnDisable()
        {
            GameManager.OnTrueAnswerChanged -= SetCurrentRightScore;
            GameManager.OnFalseAnswerChanged -= SetCurrentFalseScore;
            GameManager.OnHealthChanged -= SetCurrentHealthCount;
        }

        private void UseHint()
        {
            OnHintUsed?.Invoke();
        }

        private void SetCurrentRightScore(int value)
        {
            trueScoreText.text = $"RIGHT : {value}";
        }

        private void SetCurrentFalseScore(int value)
        {
            falseScoreText.text = $"FALSE : {value}";
        }
        private void SetCurrentHealthCount(int healthCount)
        {
            if (healthCount > livesImages.Length) return;
            livesImages[healthCount].enabled = false;
        }
    }
}
