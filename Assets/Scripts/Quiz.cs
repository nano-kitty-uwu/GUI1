using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI questionText;
	[SerializeField] QuestionCardSO cardSO;
	[SerializeField] GameObject[] answerBTNs;

	int correctAnswerIndex;
	Sprite defaultAnswerSprite;
	Sprite correctAnswerSprite;

	private void Start()
	{
		questionText.text = cardSO.GetQuestion();

		for(int i = 0;i< answerBTNs.Length; i++)
		{
			TextMeshProUGUI buttonText = answerBTNs[i].GetComponentInChildren<TextMeshProUGUI>();
			buttonText.text = cardSO.GetAnswer(i);
		}
	}
	public void OnAnswerSelected(int index)
	{
		Image buttonImage;
		if (index== cardSO.GetCorrectAnswerIndex())
		{
			questionText.text = "CORRECT";
			buttonImage = answerBTNs[index].GetComponent<Image>();
			buttonImage.sprite = correctAnswerSprite;
		}
		else
		{
			correctAnswerIndex = cardSO.GetCorrectAnswerIndex();
			string correctAnswer = cardSO.GetAnswer(correctAnswerIndex);

			questionText.text = "Sorry,the correct answer was;\n"+correctAnswer;
			buttonImage = answerBTNs[correctAnswerIndex].GetComponent<Image>();
			buttonImage.sprite = correctAnswerSprite;
		}
	}

}
