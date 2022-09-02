using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseCollision : MonoBehaviour
{
    //[SerializeField] private GameObject _hand;
    private bool _isCollision = false ;
    private float _time = 0;
    [SerializeField] private float _delayTime = 1f;//初めの1秒間はトラッカーの位置取得は行わない
    private bool _isTime = false;//初めの1秒経過後を示すフラグ

    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _delayTime)
            _isTime = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_isTime)
            _isCollision = true;
    }

    void OnCollisionExit(Collision other)
    {
        _isCollision = false;

    }

    public bool GetCollision()
    {
        return _isCollision;
    }
}
