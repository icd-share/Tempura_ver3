using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LiquidOilManager : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField] private Material _normalBoil;
    [SerializeField] private Material _inTheHandBoil;
    [SerializeField] private bool _isNormalOilOff=false;
    [SerializeField] private bool _isOncePlay=false;
    private Material _material;
    // Start is called before the first frame update
    void Start()
    { 
        _meshRenderer = GetComponent<MeshRenderer>();
       // _material = _meshRenderer.GetComponent<Material>();
       //_material = GetComponent<Renderer>().material;
       
       if (!_isNormalOilOff)
           _meshRenderer.material= _normalBoil;;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InTheHandOil()
    {
        if (!_isOncePlay)
        {
            Debug.Log("OIIIIL!!");
            _meshRenderer.material = _inTheHandBoil;
            _isOncePlay = true;
        }
    }

    public void normalOil()
    {
        if(!_isNormalOilOff)
        _meshRenderer.material= _normalBoil;
        _isOncePlay = false;
    }
}
