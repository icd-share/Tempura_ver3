using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFlybefore : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void onaudioflybefore()
    {
        _audioSource.Play();
    }
    public void offaudioflybefore()
    {
        _audioSource.Stop();
    }
}
