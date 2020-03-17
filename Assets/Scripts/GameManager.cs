using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public QuestionsManager questionsManager;
    public UIManager uIManager;

    public int score;
    public int numberOfQuestions;

    int questionCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = 0;
        questionCount = 0;
        uIManager.Introduction();
    }


    public void RestartGame ()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetNextQuestion ()
    {
        questionCount++;
        if (questionCount > numberOfQuestions)
        {
            GameEnd();
        }
        else
        {
            if (questionsManager.LoadQuestion(out Question question))
            {
                uIManager.InitialiseQuestion(question);
            }
            else
            {
                print("Couldn't load question on gamemanager");
            }
        }
       
    }

    void GameEnd ()
    {
        uIManager.Outro(score);
    }
}
