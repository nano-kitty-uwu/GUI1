using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Quiz Setup")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerBTNs;
    [SerializeField] QuestionCardSO[] questionList;

    [Header("Colors")]
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color correctColor = Color.green;
    [SerializeField] Color wrongColor = Color.red;

    private int currentQuestionIndex = 0;
    private bool hasAnswered = false;

    private void Start()
    {
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        hasAnswered = false;

        if (currentQuestionIndex >= questionList.Length)
        {
            questionText.text = "Quiz complet!";
            foreach (GameObject btn in answerBTNs)
            {
                btn.SetActive(false);
            }
            return;
        }

        QuestionCardSO currentCard = questionList[currentQuestionIndex];
        questionText.text = currentCard.GetQuestion();

        for (int i = 0; i < answerBTNs.Length; i++)
        {
            TextMeshProUGUI buttonText = answerBTNs[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentCard.GetAnswer(i);

            Button button = answerBTNs[i].GetComponent<Button>();
            button.interactable = true;

            Image img = answerBTNs[i].GetComponent<Image>();
            img.color = defaultColor;
        }
    }

    public void OnAnswerSelected(int index)
    {
        if (hasAnswered) return;
        hasAnswered = true;

        QuestionCardSO currentCard = questionList[currentQuestionIndex];
        int correctIndex = currentCard.GetCorrectAnswerIndex();

        if (index == correctIndex)
        {
            questionText.text = "CORECT!";
            SetButtonColor(index, correctColor);
        }
        else
        {
            questionText.text = "Greșit. Corect era:\n" + currentCard.GetAnswer(correctIndex);
            SetButtonColor(index, wrongColor);
            SetButtonColor(correctIndex, correctColor);
        }

        DisableAllButtons();
        StartCoroutine(NextQuestionAfterDelay(2f));
    }

    IEnumerator NextQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void SetButtonColor(int index, Color color)
    {
        Image img = answerBTNs[index].GetComponent<Image>();
        img.color = color;
    }

    void DisableAllButtons()
    {
        foreach (GameObject btn in answerBTNs)
        {
            btn.GetComponent<Button>().interactable = false;
        }
    }
}
