using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _pre;
    [SerializeField] private Material _post;
    private Renderer _renderer;
    private Material _material;
    private Color _particleColor;
    [SerializeField]private Color _startColor = new Color(232 / 255f, 232 / 255f, 25 / 255f, 1.0f); //変化前の手の色
    [SerializeField]private Color _targetColor = new Color(251/255f,205/255f,40/255f,1.0f);//変化後の手の色
    private Color black = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    private float _totalTime;
    //[SerializeField] private float _overTime = 60f; //（揚げ時間の最大値）
    //[SerializeField] private float _targetTime = 30f; // 目標時間
    private int _totalTimeint;
    //private float _goalTime;//目標とする時間（揚げ時間の最大値）
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _startColor;
        _totalTime = 0;
        //_startTime = 0.0f;
        //_goalTime = 3.0f;
    }

//デバッグ用の過去のupdete関数．下のpublic関数と一緒です．
/*void Update()
{

    if (Input.GetKey(KeyCode.Space))
    
    {
        Debug.Log("Space is pushed!");
        _totalTime += Time.deltaTime;
    }   
    //0.5*targetTimeから1.1*targetTimeまでは_startcolorから_targetcolorまで線形に揚げられる．
    if (_totalTime >= 0.5 * _targetTime && _totalTime<1.1*_targetTime)
    {
        float lerpTime = (_totalTime-0.5f*_targetTime ) / ((1.1f-0.5f)*_targetTime );
        lerpTime = Mathf.Min(1.0f, lerpTime);
        lerpTime = Mathf.Max(0.0f, lerpTime);
        _renderer.material.color =
            Color.Lerp(_startColor, _targetColor, lerpTime);//色を線形的に変える
        //_renderer.material = _pre; 
        Debug.Log("0.5~1.1");
    }
    //1.1*targetTimeから1.5*targetTimeまで，_targetcolorからblackまで線形的に色が変わる．
    else if (_totalTime >= 1.1 * _targetTime && _totalTime < 1.5 * _targetTime)
    {
        float lerpTime = (_totalTime-1.1f*_targetTime ) / ((1.5f-1.1f)*_targetTime );
        lerpTime = Mathf.Min(1.0f, lerpTime);
        lerpTime = Mathf.Max(0.0f, lerpTime);
        _renderer.material.color =
            Color.Lerp(_targetColor, black, lerpTime);//
        Debug.Log("1.1~1.5");
    }
    
}
*/
    public void colorchanger(float totalTime,float _targetTime)
    {
        _totalTime = totalTime;
        _renderer = GetComponent<Renderer>();
        //0.5*targetTimeから1.1*targetTimeまでは_startcolorから_targetcolorまで線形に揚げられる．
        if (_totalTime >= 0.5 * _targetTime && _totalTime<1.1*_targetTime)
        {
            
            float lerpTime = (_totalTime-0.5f*_targetTime ) / ((1.1f-0.5f)*_targetTime );
            lerpTime = Mathf.Min(1.0f, lerpTime);
            lerpTime = Mathf.Max(0.0f, lerpTime);
            lerpTime = 0.5f;
            _renderer.material.color =
                Color.Lerp(_startColor, _targetColor, lerpTime);//色を線形的に変える
        }
        //1.1*targetTimeから1.5*targetTimeまで，_targetcolorからblackまで線形的に色が変わる．
        else if (_totalTime >= 1.1 * _targetTime && _totalTime < 1.5 * _targetTime)
        {
            float lerpTime = (_totalTime-1.1f*_targetTime ) / ((1.5f-1.1f)*_targetTime );
            lerpTime = Mathf.Min(1.0f, lerpTime);
            lerpTime = Mathf.Max(0.0f, lerpTime);
            _renderer.material.color =
                Color.Lerp(_targetColor, black, lerpTime);
        }
    }

    public Color partcicleColorChanger(float _totalTime,float _targetTime)
    {
        //_material = GetComponent<Material>();
        /*if (_totalTime < _targetTime)
        {
            _particleColor = _startColor;
        }
       
        else if(_totalTime>_targetTime)
        {
            _particleColor = _targetColor;
        }*/
        _particleColor = _startColor;
        if (_totalTime >= 0.5 * _targetTime && _totalTime<1.1*_targetTime)
        {
            
            float lerpTime = (_totalTime-0.5f*_targetTime ) / ((1.1f-0.5f)*_targetTime );
            lerpTime = Mathf.Min(1.0f, lerpTime);
            lerpTime = Mathf.Max(0.0f, lerpTime);
            lerpTime = 0.5f;
            _particleColor =
                Color.Lerp(_startColor, _targetColor, lerpTime);//色を線形的に変える
        }
        //1.1*targetTimeから1.5*targetTimeまで，_targetcolorからblackまで線形的に色が変わる．
        else if (_totalTime >= 1.1 * _targetTime && _totalTime < 1.5 * _targetTime)
        {
            float lerpTime = (_totalTime-1.1f*_targetTime ) / ((1.5f-1.1f)*_targetTime );
            lerpTime = Mathf.Min(1.0f, lerpTime);
            lerpTime = Mathf.Max(0.0f, lerpTime);
            _particleColor =
                Color.Lerp(_targetColor, black, lerpTime);
        }
        return  _particleColor;

    }
}  