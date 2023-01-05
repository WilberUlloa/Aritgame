using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerValidate : MonoBehaviour
{
    public bool isCorrect = false;
    [SerializeField] QuestManager qm;
    [SerializeField] Timer timer;

    public void Answer()
    {
        if(isCorrect)
        {
            timer.ResetTimer();
            Debug.Log("CORRECT ANSWER");
            qm.SetCorrect();
        }
        else
        {
            Debug.Log("WRONG ANSWER");
            qm.SetCorrect();
        }
    }
}
