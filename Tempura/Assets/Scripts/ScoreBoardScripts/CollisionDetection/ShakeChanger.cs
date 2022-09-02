using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeChanger : MonoBehaviour
{
    [SerializeField] private int _level = 60;
    //private ShakeManager shakemanager;
    //private int _test = ShakeManager._level;
    [SerializeField] private ShakeManager _shakemanager;
    //private ShakeManager _shakemanager;
    private float _totalTime;
    [SerializeField] private float _overTime = 60f; //（揚げ時間の最大値）
    //[SerializeField] private float _targetTime = 30f; // 目標時間
    private int _totalTimeint;
    [SerializeField]private int _maxShake=60;
    [SerializeField]private int _minShake=20;
    [SerializeField]private int _goodShake=40;
    // Start is called before the first frame update
    void Start()
    {
        _totalTime = 0;
        
        //int targetLevel = 40;
        //ShakeManager script = new ShakeManager();

    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _totalTime += Time.deltaTime;
        
        
        float lerpTime = (_totalTime) / (_overTime);
        lerpTime = Mathf.Min(1.0f, lerpTime);
        lerpTime = Mathf.Max(0.0f, lerpTime);
        //0秒から0.5*targetTimeまではmaxshakeで振動
        if (_totalTime > 0 && _totalTime <= 0.5 * _targetTime)
        {
            _level = _maxShake;
        }  
        //0.5*targetTimeから0.9*targetTimeまでは線形で振動が減少
        else if (_totalTime >= 0.5 * _targetTime && _totalTime < 0.9 * _targetTime)
        {
            _level = Mathf.RoundToInt((float)(_goodShake +
                                              (_maxShake - _goodShake) * (0.9 * _targetTime - _totalTime) /
                                              ((0.9-0.5) * _targetTime)));
        }
        //0.9*targetTimeから1.1*targetTimeまではgoodShakeで振動
        else if (_totalTime >= 0.9 * _targetTime && _totalTime <1.1 * _targetTime)
        {
            _level = _goodShake;
        }
        //1.1*targetTime以降は線形にminShakeまで減少．1.75*targetTimeで20になるよう調整済み
        else if (_totalTime >= 1.1 * _targetTime &&_totalTime<1.75*_targetTime)
        {
            _level = Mathf.RoundToInt((float)(_minShake +
                                              (_goodShake - _minShake) * (1.75 * _targetTime - _totalTime) /
                                              ((1.75-1.1) * _targetTime)));
        }
        //1.75*targetTime以降はminShakeで振動
        else if (_totalTime >= 1.75 * _targetTime)
        {
            _level = _minShake;
        }
        //_levelc = Mathf.RoundToInt(_maxshake - (_endshake * lerpTime));
        _shakemanager.ShakeLevel(_level);//shakemanegerに_levelを代入
        //if (10>_level && _level > _minshake)
        //{
            Debug.Log("_level=" + _level);
            
        //}
    }*/
    public void shakechanger(float totalTime,float _targetTime)
    {
        _totalTime = totalTime;
        float lerpTime = (_totalTime) / (_overTime);
        lerpTime = Mathf.Min(1.0f, lerpTime);
        lerpTime = Mathf.Max(0.0f, lerpTime);
        //0秒から0.5*targetTimeまではmaxshakeで振動
        if (_totalTime > 0 && _totalTime <= 0.5 * _targetTime)
        {
            _level = _maxShake;
        }  
        //0.5*targetTimeから0.9*targetTimeまでは線形で振動が減少
        else if (_totalTime >= 0.5 * _targetTime && _totalTime < 0.9 * _targetTime)
        {
            _level = Mathf.RoundToInt((float)(_goodShake +
                                              (_maxShake - _goodShake) * (0.9 * _targetTime - _totalTime) /
                                              ((0.9-0.5) * _targetTime)));
        }
        //0.9*targetTimeから1.1*targetTimeまではgoodShakeで振動
        else if (_totalTime >= 0.9 * _targetTime && _totalTime <1.1 * _targetTime)
        {
            _level = _goodShake;
        }
        //1.1*targetTime以降は線形にminShakeまで減少．1.75*targetTimeで20になるよう調整済み
        else if (_totalTime >= 1.1 * _targetTime &&_totalTime<1.75*_targetTime)
        {
            _level = Mathf.RoundToInt((float)(_minShake +
                                              (_goodShake - _minShake) * (1.75 * _targetTime - _totalTime) /
                                              ((1.75-1.1) * _targetTime)));
        }
        //1.75*targetTime以降はminShakeで振動
        else if (_totalTime >= 1.75 * _targetTime)
        {
            _level = _minShake;
        }
        _shakemanager.ShakeLevel(_level);
        //Debug.Log("_level=" + _level);    //秒数取得の邪魔だったので一旦コメントアウトしました(木村)
    }
}
