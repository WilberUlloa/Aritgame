using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("playSound").GetComponent<SoundGeneral>().StopSound();   

    }
}
