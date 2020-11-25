using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnTrueAnswerChanged;
    public static event Action<int> OnFalseAnswerChanged;
    public static event Action<int> OnHealthChanged;
    public static event Action<int, int, string> OnGameEnded;
    
    [Header("Question")]
    [SerializeField] private Image questionImage;
    [SerializeField] private Button[] answersButtons;

    [Header("Data")]
    [SerializeField] private List<QuestionData> allQuestions;

    [SerializeField] private CanvasGroup finalPanel;
    
    [SerializeField] private int healthCount = 3;

    private int _trueAnswerCount;
    private int _falseAnswerCount;

    private const string LoseMessage = "YOU LOSE!";
    private const string WinMessage = "YOU WIN";
    public Button[] AnswersButtons => answersButtons;
    public QuestionData CurrentQuestion { get; private set; }
    private int TrueAnswerCount
    {
        get => _trueAnswerCount;
        set
        {
            _trueAnswerCount = value;
            OnTrueAnswerChanged?.Invoke(_trueAnswerCount);
        }
    }

    private int FalseAnswerCount
    {
        get => _falseAnswerCount;
        set
        {
            _falseAnswerCount = value;
            OnFalseAnswerChanged?.Invoke(_falseAnswerCount);
        }
    }

    private void OnEnable()
    {
        SetQuestion();
    }
    private void SetQuestion()
    {
        if (allQuestions.Count <= 0)
        {
            finalPanel.gameObject.SetActive(true);
            OnGameEnded?.Invoke(_trueAnswerCount,_falseAnswerCount,WinMessage);
        }
        else
        {
            var questionIndex = Random.Range(0, allQuestions.Count - 1);
            CurrentQuestion= allQuestions[questionIndex];
            questionImage.sprite = CurrentQuestion.Image;
            for (var i = 0; i < answersButtons.Length; i++)
            {
                answersButtons[i].GetComponentInChildren<Text>().text = CurrentQuestion.Answers[i].ToUpper();
            }
        }
    }
    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == CurrentQuestion.RightAnswer)
        {
            TrueAnswerCount++;
        }
        else if (answerIndex != CurrentQuestion.RightAnswer)
        {
            FalseAnswerCount++;
            healthCount--;
            if (healthCount == 0)
            {
                finalPanel.gameObject.SetActive(true);
                OnGameEnded?.Invoke(_trueAnswerCount, _falseAnswerCount, LoseMessage);
            }
            OnHealthChanged?.Invoke(healthCount);
        }
        allQuestions.Remove(CurrentQuestion);
        SetQuestion();
        RestartButtons();
    }
    private void RestartButtons()
    {
        foreach (var button in answersButtons)
        {
            button.interactable = true;
        }
    }
}
