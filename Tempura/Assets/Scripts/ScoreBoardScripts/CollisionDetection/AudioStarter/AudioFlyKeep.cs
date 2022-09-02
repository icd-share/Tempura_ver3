using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFlyKeep : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void onaudioflykeep()
    {
        _audioSource.Play();
    }
    public void changepitchvolume(float audioPitch,float audioVolume)
    {
        _audioSource.pitch = audioPitch;
        _audioSource.volume = audioVolume;
    }
    public void onaudioflykeeploop()
    {
        _audioSource.loop = true;
    }
    public void offaudioflykeep()
    {
        _audioSource.Stop();
    }

   
}
