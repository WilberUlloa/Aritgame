using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerValidate : MonoBehaviour
{
    public bool isCorrect = false;
    [SerializeField] QuestManager qm;
    [SerializeField] Timer timer;
    public GameObject AlertCorrect;
    public GameObject AlertWrong;
    private SoundManager sm;

    public void Awake()
    {
        sm = FindObjectOfType<SoundManager>();
    }

    public void ShowAlert(GameObject imageAlert)
    {
        imageAlert.SetActive(true);
    }
    public void BacktoNormal()
    {
        AlertCorrect.SetActive(false);
        AlertWrong.SetActive(false);
    }

    public void Answer()
    {
        if(isCorrect)
        {
            timer.ResetTimer();
            ShowAlert(AlertCorrect);
            qm.SetCorrect();
            sm.selectAudio(4);
        }
        else
        {
            ShowAlert(AlertWrong);
            qm.SetCorrect();
            sm.selectAudio(3);
        }
    }
}
