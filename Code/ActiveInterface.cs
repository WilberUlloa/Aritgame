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
    [SerializeField] Timer tm;

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
            tm.PauseTimer();
            status = false;

        }else
        {
            status = true;
            DeactivateCvs(ChanllCvs);
            tm.ResumeTimer();
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
