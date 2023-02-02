using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource controlerSound;

    public void Awake()
    {
        controlerSound = GetComponent<AudioSource>();
    }

    public void ActivateSound(int index, float volume)
    {
        controlerSound.PlayOneShot(sounds[index], volume);
    }
}
