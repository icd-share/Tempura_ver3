using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositionDetactor : MonoBehaviour
{
    //[SerializeField] private GameObject _tracker;
    //[SerializeField] private GameObject _offseter;
    //[SerializeField] private Vector3 _offset;

    [Header("CalibrationManagerをセット")]
    [SerializeField] private CalibrationManager _calibrationManager;
    
    [SerializeField] private float _handObjectLen=0.17f;

    private float _handRatio, _handRealLen;
    
    private Vector3 _handScale;

    // Start is called before the first frame update
    void Start()
    {
        //_offset = _offseter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _handRealLen = _calibrationManager.GetHandLen();
        
        _handRatio = _handRealLen / _handObjectLen;
        _handScale.x = _handRatio;
        _handScale.y = _handRatio;
        _handScale.z = _handRatio;
        /*
        _offset.x = _handRealLen / 2;
        _offset.y = _handRealLen / 2;
        _offset.z = - _handRealLen / 2;
        */
        //this.transform.position = _tracker.transform.position + _offset;
        //this.transform.rotation = _tracker.transform.rotation;
        this.transform.localScale = _handScale;
    }
}
