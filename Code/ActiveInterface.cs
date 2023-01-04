using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveInterface : MonoBehaviour
{
    public GameObject PauCvs;
    public GameObject RestCvs;
    public GameObject BackRCvs;
    public GameObject ChanllCvs;
    public bool ChangeStatus = true;
    //public GameObject[] arrayIU;

    public void ActivatePause()
    {
        if (ChangeStatus)
        {
            ActivateCvs(PauCvs);
            Time.timeScale = 0;
            ChangeStatus = false;
        }else
        {
            ChangeStatus = true;
            DeactivateCvs(PauCvs);
            Time.timeScale = 1;
        }
    }

    public void ActivateRestartGame(bool status)
    {
        if(status)
        {
            ActivateCvs(RestCvs);
            status = false;
        }else
        {
            status = true;
            DeactivateCvs(RestCvs);
        }
    }

    public void ActivateBR(bool status)
    {
        if(status)
        {
            ActivateCvs(BackRCvs);
            status = false;
        }else
        {
            status = true;
            DeactivateCvs(BackRCvs);
        }
    }

    public void ActivateChallenges(bool status)
    {
        if(status)
        {
            ActivateCvs(ChanllCvs);
            Time.timeScale = 0;
            status = false;
            //int n = Random.Range(0, arrayIU.Length);
            //arrayIU[n].SetActive(true);

        }else
        {
            status = true;
            DeactivateCvs(ChanllCvs);
            Time.timeScale = 1;
            //int n = Random.Range(0, arrayIU.Length);
            //arrayIU[n].SetActive(false);
        }
    }

    public void ActivateCvs(GameObject canvas)
    {
        canvas.SetActive(true);
        
    }

    public void DeactivateCvs(GameObject canvas)
    {
        canvas.SetActive(false);
    }
}
