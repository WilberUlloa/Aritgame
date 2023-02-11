using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    void Start()
    {
     GameObject.FindGameObjectWithTag("playSound").GetComponent<SoundGeneral>().PlaySound();
    }
}
