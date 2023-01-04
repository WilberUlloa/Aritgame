using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] LifeBar lifeBar;
    [SerializeField] ActiveInterface ai;
    [SerializeField] private float MaxTime;
    private float ActualTime;
    private bool linked = true;

    void Start()
    {
        ActualTime = MaxTime;
        lifeBar.GetMaxValue(MaxTime);
    }

    void Update()
    {
        if(linked)
        {
            ActualTime -= Time.deltaTime;
            lifeBar.UpdateBar(ActualTime);
            ai.ActivateRestartGame(false);


            if(ActualTime <= 0)
            {
                linked = false;
                ai.ActivateRestartGame(true);
            }
        }
    }

    public void ResetTimer()
    {
        lifeBar.UpdateBar(MaxTime);
        ActualTime = MaxTime;
        linked = true;
    }


    public void SubtractTime()
    {
        ActualTime--;
        linked = true;
    }
}
