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
    private SoundManager sm;

    private void Awake()
    {
     status = true;
     valueClock = 30f;
     sm = FindObjectOfType<SoundManager>();
    }

 public void Update()
    {
      if(status)
        {
            valueClock -= Time.deltaTime;
            int tm = Mathf.FloorToInt(valueClock);
            TextClock.text = ""+tm;
            sm.ActivateSound(10, 0.30f);

            if(valueClock <= 0)
            {
                status = false;
                ai.ActivateChallenges(false);
            }
        }  
    }
}
