using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ParticleChangerHara : MonoBehaviour
{
    ParticleSystem m_ParticleSystem;
    [SerializeField] private GameObject _particle;
    private ParticleSystem.Particle[] m_Particles;
    private ParticleSystemRenderer m_ParticleRenderer;
    [SerializeField] private ColorChanger _colorChanger;
    private Renderer _renderer;
    private Material _material;
    // Start is called before the first frame update
    void Start()
    {
        m_ParticleSystem = _particle.GetComponent<ParticleSystem>();
        m_ParticleRenderer =_particle.GetComponent<ParticleSystemRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_ParticleSystem.Pause();
        }
    }

    public void particlecolorhara(float _totalTime, float _targetTime)
    {
        m_ParticleRenderer.material.color=_colorChanger.partcicleColorChanger(_totalTime,_targetTime);
    }

    public void OnParticlehara(float _deleyTime)
    {
        m_ParticleSystem.startDelay =  _deleyTime;
        m_ParticleSystem.Play();
    }
}
