using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    
    [SerializeField] private Image bar;
    [SerializeField] private float MaxSize;
    private float ActualSize;
    private float MaxValue;

    public void GetMaxValue(float ParaMaxValue)
    {
        MaxValue = ParaMaxValue;
    }

    public void UpdateBar(float ParaActualValue)
    {
        ActualSize = ParaActualValue * MaxSize / MaxValue;
        bar.fillAmount = ActualSize;
    }    
}
