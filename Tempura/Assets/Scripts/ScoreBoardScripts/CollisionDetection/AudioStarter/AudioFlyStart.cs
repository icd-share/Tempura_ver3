using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFlyStart : MonoBehaviour
{
    private AudioSource _audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void onaudioflystart()
    {
        _audioSource.time = 2.3f;
        _audioSource.Play();
    }
    public void offaudioflystart()
    {
        _audioSource.Stop();
    }
}
