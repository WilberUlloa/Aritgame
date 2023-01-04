using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public List<QuesAndAnsw> qa;
    public GameObject[] optionsBtns;
    public int currentQuestion;
    public Text questionText;

    private void Start()
    {
        GenerateQ();
    }

    void GenerateQ()
    {
        currentQuestion = Random.Range(0, qa.Count);
        questionText.text = qa[currentQuestion].question;
        SetAnsw();
    }

    void SetAnsw()
    {
        for(int i = 0; i < optionsBtns.Length; i++)
        {
            optionsBtns[i].GetComponent<AnswerValidate>().isCorrect = false;
            optionsBtns[i].transform.GetChild(0).GetComponent<Text>().text = qa[currentQuestion].options[i];
            
            if(qa[currentQuestion].correct_answer == i+1)
            {
                optionsBtns[i].GetComponent<AnswerValidate>().isCorrect = true;
            }
        }
    }

    public void SetCorrect()
    {
        GenerateQ();
    }
}
