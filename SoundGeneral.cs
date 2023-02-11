using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGeneral : MonoBehaviour
{
    private static AudioSource _audiosource;

    public void Awake()
    {
        if(_audiosource != null)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
            _audiosource = GetComponent<AudioSource>();
        }
    }

    public void PlaySound()
    {
        if(_audiosource.isPlaying) return;
        _audiosource.Play();
    }

    public void StopSound()
    {
        _audiosource.Stop();
    }

    public void PuaseSound()
    {
        _audiosource.Pause();
    }
}
