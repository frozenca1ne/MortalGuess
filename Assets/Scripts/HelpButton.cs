using System;
using UI;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int hintCount = 2;

    private void OnEnable()
    {
        GameUiView.OnHintUsed += UseHelp;
    }

    private void OnDisable()
    {
        GameUiView.OnHintUsed -= UseHelp;
    }

    private void UseHelp()
    {
        Debug.Log("Hello!");
        if(hintCount == 0) return;
        hintCount--;
        var disabledButtons = 0;
        for (var i = 0; i < gameManager.AnswersButtons.Length; i++)
        {
            if(disabledButtons == 2) break;
            var button = gameManager.AnswersButtons[i];
            if(i == gameManager.CurrentQuestion.RightAnswer) continue;
            button.interactable = false;
            disabledButtons++;
        }
    }
}
