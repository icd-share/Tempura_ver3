using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    [SerializeField] private AudioFlyafter _audioFlyafter;
    [SerializeField] private AudioFlybefore _audioFlybefore;
    [SerializeField] private AudioFlyKeep _audioFlyKeep;
    [SerializeField] private AudioFlyStart _audioFlyStart;
    [SerializeField] private float _audioPitch=1.0f;
    [SerializeField] private float _audioVolume=1.0f;
  
    public void audiochanger(float _totalTime,float _targetTime)//時間は感覚で決めているので，調整しましょう．
    {
        if (_totalTime>0 && _totalTime<0.03f) 
        {
            _audioPitch=1.0f;
            _audioVolume=1.0f;
            _audioFlyStart.onaudioflystart();//最初の投入音
        }

        else if (_totalTime > 6.0f && _totalTime < 6.03f)//ちょっと音の変化
        {
            _audioFlyKeep.onaudioflykeep();//ちょっと音の変化
        }
        else if (_totalTime >  _targetTime-20.0f && _totalTime < _targetTime-20.0f+0.03f)//少し音の高さを上げた
        {
            _audioPitch = 1.2f;
            _audioVolume = 0.9f;
            _audioFlyKeep.changepitchvolume(_audioPitch,_audioVolume);
            _audioFlyKeep.onaudioflykeeploop();
        }

        else if (_totalTime > _targetTime-9.0f && _totalTime < _targetTime-9.0f+0.3f)//少し音を揚げ，音量を小さく．
        {
            _audioPitch = 1.5f;
            _audioVolume = 0.77f;
            _audioFlyKeep.changepitchvolume(_audioPitch,_audioVolume);
            //_audioFlyKeep.onaudioflykeep();
        }
        else if (_totalTime > _targetTime-2.0f && _totalTime < _targetTime-2.0f+0.3f)//少し高さを上げ，音量を小さく
        {
            _audioPitch = 1.7f;
            _audioVolume= 0.56f;
            _audioFlyKeep.changepitchvolume(_audioPitch,_audioVolume);
            //_audioFlyKeep.onaudioflykeep();
        }
        else if (_totalTime > _targetTime+7.0f && _totalTime < _targetTime+7.3f)//少し高さを上げ，音量を小さく
        {
            _audioPitch = 1.83f;
            _audioVolume= 0.46f;
            _audioFlyKeep.changepitchvolume(_audioPitch,_audioVolume);
            //_audioFlyKeep.onaudioflykeep();
        }
        else if (_totalTime > _targetTime+15.0f && _totalTime < _targetTime+15.3f) //少し高さを上げ，音量を小さく．これ以降は同じ音の繰り返し．
        {
            _audioPitch = 1.9f;
            _audioVolume = 0.36f;
            _audioFlyKeep.changepitchvolume(_audioPitch,_audioVolume);
            //_audioFlyKeep.onaudioflykeep();
            //_audioFlyKeep.onaudioflykeeploop();
        }
        
    }

    public void audioafter(float _totalTime) //手んぷらを油から取り出した際の音．
    {
        if (_totalTime < 30.0f)
        {
            _audioPitch = 1.2f;
            _audioVolume = 1.4f;
        }

        _audioFlyafter.onaudioflyafter(_audioPitch, _audioVolume);
    }

    public void audioNidoduke()//手んぷらを二度付けした際の音
    {
        _audioFlyKeep.changepitchvolume(_audioPitch,_audioVolume);
        _audioFlyKeep.onaudioflykeep();
        
    }
    
    public void stopfryaudio()//再生中の音を消す．基本的にkeepが消される．
    {
        _audioFlybefore.offaudioflybefore();
        _audioFlyStart.offaudioflystart();
        _audioFlyKeep.offaudioflykeep();
    }
}
