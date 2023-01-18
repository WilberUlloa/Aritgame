using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valider : MonoBehaviour
{
    public bool opcCorrect;
    [SerializeField] QuestMana qm;
    public GameObject AlertCorrect;
    public GameObject AlertWrong;

    public void ShowAlert(GameObject imageAlert)
    {
        imageAlert.SetActive(true);
    }
    
    public void NoShowAlert(GameObject imageAlert)
    {
        imageAlert.SetActive(false);
    }

     public void Answer()
    {
        if(opcCorrect)
        {
            ShowAlert(AlertCorrect);
            NoShowAlert(AlertWrong);
            qm.SetCorrect();
        }
        else
        {
            ShowAlert(AlertWrong);
            NoShowAlert(AlertCorrect);
            qm.SetCorrect();
        }
    }
}
