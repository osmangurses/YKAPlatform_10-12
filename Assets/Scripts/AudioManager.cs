using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Start()
    {
        Instance = this;
    }
    public AudioSource[] audios;



    public void PlayRunSound()
    {
        audios[0].Play();
    }
    public void PlayCollectSound()
    {
        audios[1].Play();
    }
    public void PlayFailSound()
    {
        audios[2].Play();
    }
    public void PlayJumpSound()
    {
        audios[3].Play();
    }
    public void PlayCompleteSound()
    {
        audios[4].Play();
    }
    public void StopRunSound()
    {
        audios[0].Stop();
    }
}
