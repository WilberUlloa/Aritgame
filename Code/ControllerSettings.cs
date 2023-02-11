using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSettings : MonoBehaviour
{
    public GameObject btnSoundOn;
    public GameObject btnSoundOff;
    public GameObject imgTitleAct;
    public GameObject imgTitleDeact;
    public GameObject canvas;

    public void OffSound()
    {
        btnSoundOn.SetActive(false);
        btnSoundOff.SetActive(true);

        imgTitleAct.SetActive(false);
        imgTitleDeact.SetActive(true);
        GameObject.FindGameObjectWithTag("playSound").
            GetComponent<SoundGeneral>().PuaseSound();  

    }

    public void OnSound()
    {
        btnSoundOff.SetActive(false);
        btnSoundOn.SetActive(true);

        imgTitleDeact.SetActive(false);
        imgTitleAct.SetActive(true);
        GameObject.FindGameObjectWithTag("playSound").
            GetComponent<SoundGeneral>().PlaySound(); 
    }

    public void ShowCanvas()
    {
        canvas.SetActive(true);
    }
    public void NoShowCanvas()
    {
        canvas.SetActive(false);
    }
}
