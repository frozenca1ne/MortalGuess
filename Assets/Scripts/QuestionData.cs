using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private string[] answers;
    [SerializeField] private int rightAnswer;

    public Sprite Image => image;

    public string[] Answers => answers;

    public int RightAnswer => rightAnswer;

}
