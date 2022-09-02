using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFlyafter : MonoBehaviour
{
    private AudioSource _audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void onaudioflyafter(float _audioPitch, float _audioVolume)
    {
        _audioSource.time = 1.8f;//スタート時間をずらす．
        _audioSource.pitch = _audioPitch;//ピッチを変更．
        _audioSource.volume = _audioVolume;//音量を変更
        _audioSource.Play();
    }
    public void offaudioflyafter()
    {
        _audioSource.Stop();//音を止める．
    }
}
