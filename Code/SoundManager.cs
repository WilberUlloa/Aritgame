using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource soundcontroller;

    public void Awake(){
        soundcontroller = GetComponent<AudioSource>();
    }

    public void selectAudio(int index)
    {
        soundcontroller.PlayOneShot(sounds[index]);
    }
}
