using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleChangerHara _particleChangerHara;
    [SerializeField] private ParticleChangerSmall _particleChangerSmall;
    [SerializeField] private ParticleChangerKo _particleChangerKo;
    [SerializeField] private float _startTime;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnParticle(float _tartgetTime)
    {
        startTime = _startTime;
        _particleChangerHara.OnParticlehara(startTime);
        _particleChangerKo.OnParticleKo(startTime);
        _particleChangerSmall.OnParticlesmall();
    }

    public void ParticleColor(float _totalTime, float _targetTime)
    {
        _particleChangerSmall.particlecolorsmall(_totalTime,_targetTime);
        _particleChangerHara.particlecolorhara(_totalTime,_targetTime);
        _particleChangerKo.particlecolorKo(_totalTime,_targetTime);
    }
}
