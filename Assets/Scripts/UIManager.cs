using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text speechText;
    public Text correctAnswerText;
    public Text wrongAnswerText;

    public Button correctAnswerButton;
    public Button wrongAnswerButton;
    public Button nextButton;

    public Button quitButton;
    public Button restartButton;

    public float delayTime;

    Question currentQuestion;

    public string[] introDialogue;
    int index = 0;
    
    public void Introduction ()
    {
        speechText.text = introDialogue[index];
        nextButton.gameObject.SetActive(true);
        correctAnswerButton.gameObject.SetActive(false);
        wrongAnswerButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void Outro (int totalScore)
    {
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        switch (totalScore)
        {
            case 0:
                speechText.text = "You got no points, You should defintely try again";
                break;
            case 1:
                speechText.text = "You only got one point, you need to try again";
                break;
            case 2:
                speechText.text = "Two points, I know you can do better";
                break;
            case 3:
                speechText.text = "That's good but I know you got more in you.";
                break;
            case 4:
                speechText.text = "So close, I think you are ready but if you'd like to again you can. ";
                break;
            case 5:
                speechText.text = "Perfect score. You're ready to take on the world";
                break;

            default:
                break;
        }
    }

    public void InitialiseQuestion (Question question)
    {
        currentQuestion = question;
        speechText.text = question.question;
        correctAnswerText.text = question.correctAnswer;
        wrongAnswerText.text = question.wrongAnwser;
        StartCoroutine("DelayAnswerPopup");
    }

    IEnumerator DelayAnswerPopup()
    {
        yield return new WaitForSeconds(delayTime);
        correctAnswerButton.gameObject.SetActive(true);
        wrongAnswerButton.gameObject.SetActive(true);
        correctAnswerButton.gameObject.transform.SetSiblingIndex(Random.Range(0,2));
    }

    public void CorrectAnswerButton ()
    {
        GameManager.instance.score++;
        speechText.text = "That is correct.\nGreat job!";
        StartCoroutine("DelayNextQuestion");
    }

    public void IncorrectAnswerButton ()
    {
        speechText.text = "That is incorrect.\nBetter luck next time.";
        StartCoroutine("DelayNextQuestion");
    }

    IEnumerator DelayNextQuestion ()
    {
        correctAnswerButton.gameObject.SetActive(false);
        wrongAnswerButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(delayTime);
        GameManager.instance.SetNextQuestion();
    }

    public void NextButton()
    {
        if (index < introDialogue.Length - 1)
        {
            index++;
            speechText.text = introDialogue[index];
        }
        else
        {
            nextButton.gameObject.SetActive(false);
            GameManager.instance.SetNextQuestion();
        }
    }
}
