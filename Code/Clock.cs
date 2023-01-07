using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextClock;
    [SerializeField] ActiveInterface ai;
    private float valueClock;
    private bool status;

    private void Awake()
    {
     status = true;
     valueClock = 40f;
    }

    void Update()
    {
      if(status)
        {
            valueClock -= Time.deltaTime;
            int tm = Mathf.FloorToInt(valueClock);
            TextClock.text = ""+tm;

            if(valueClock <= 0)
            {
                status = false;
                ai.ActivateChallenges(false);
            }
        }  
    }
}
