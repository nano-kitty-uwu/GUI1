using UnityEngine;

[CreateAssetMenu(fileName = "QuestionCardSO", menuName = "Scriptable Objects/QuestionCardSO")]
public class QuestionCardSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] ansewrs = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return ansewrs[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }


}
