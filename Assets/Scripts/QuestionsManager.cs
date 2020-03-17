using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    public List<Question> questionsList = new List<Question>();
    void Start()
    {
        
    }

    public bool LoadQuestion (out Question question)
    {
        question = null;
        if (questionsList != null)
        {
            int randInt = 0;
            if (questionsList.Count > 0)
            {
                randInt = Random.Range(0, questionsList.Count);
            }
            question = questionsList[randInt];
            questionsList.Remove(questionsList[randInt]);
            return true;
        }

        return false;
    }

    
}


[System.Serializable]
public class Question
{
    public string question;
    public string correctAnswer;
    public string wrongAnwser;
}



