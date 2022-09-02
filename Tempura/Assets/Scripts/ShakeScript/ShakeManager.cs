using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.PlayerLoop;

public class ShakeManager : MonoBehaviour
{
    [SerializeField] private SerialPortUtility.SerialPortUtilityPro _serialPort = null;
    //[SerializeField] private static int _level = 0; //板倉追加　_levelをパブリックに変更．
    [SerializeField] private int _level = 0;
    [SerializeField] private bool _isOn = false;
    [SerializeField] private float _onoffSpan = 10f;
    [SerializeField] private bool _isDebug;

    private float _time = 9f;

    // Start is called before the first frame update
    void Start()
    {
        /* --For test
        _serialPort.Write("u");
        _serialPort.Write("d");
        */
    }

    // Update is called once per frame
    void Update()
    {
        //デバック用
        if (_isDebug)
        {
            if (Input.GetKeyDown(KeyCode.O))
                ShakeUp(1);
            if (Input.GetKeyDown(KeyCode.K))
                ShakeDown(1);
            if (Input.GetKeyDown(KeyCode.M))
                ShakeLevel(60);
            if (Input.GetKeyDown(KeyCode.N))
            {
                _serialPort.Write("m");//Maxに持っていく命令を飛ばす
                _level = 60;
            }
            if (Input.GetKeyDown(KeyCode.P))
                ShakeStart();
        }
        if (_level ==0)
            ConfirmOff();

        if (!_isOn)
            _time += Time.deltaTime;

        if (_time > _onoffSpan && !_isOn) {
            _time = 0;
            OnoffChanger();
        }

    }

    public void ShakeStart()
    {
        _serialPort.Write("s");
        _isOn = !_isOn;
        if (_isOn)
            _level = 1;
        else
            _level = 0;
    }

    private void ConfirmOn() //ONであることを確かめ，OFFならONにする
    {
        if (!_isOn)
        {
            _serialPort.Write("s");
            _isOn = true;
        }
    }

    private void ConfirmOff() //OFFであることを確かめ，ONならOFFにする
    {
        if (_isOn)
        {
            _serialPort.Write("s");
            _isOn = false;
        }
    }
    
    public bool ChakeOn()
    {
        return _isOn;
    }
    public void ShakeUp(int upCount)
    {
        StartCoroutine("ShakeUpCoroutine", upCount);
    }
    
    private IEnumerator ShakeUpCoroutine(int upCount)
    {
        while (upCount > 0)
        {
            ShakeUp();
            yield return new WaitForSeconds(0.10f);
            upCount--;
        }
    }
    
    void ShakeUp()
    {
        ConfirmOn();
        if (_level >= 60)
            return;
        _serialPort.Write("u");//upCountの分だけ振動レベルup
        _level += 1;
    }


    public void ShakeDown(int downCount)
    {
        StartCoroutine("ShakeDownCoroutine", (downCount));
    }
    
    private IEnumerator ShakeDownCoroutine(int downCount)
    {
        while (downCount > 0)
        {
            ShakeDown();
            yield return new WaitForSeconds(0.10f);
            downCount--;
        }
    }
    void ShakeDown()
    {
        ConfirmOn();
        if (_level <= 0)
            return;
        _serialPort.Write("d");//downCountの分だけ振動レベルdown
        _level -= 1;
    }
    
    public int GetShakeLevel()
    {
        return _level;
    }

    public void ShakeLevel(int targetLevel) //目当てのレベルに設定
    {
        int i = targetLevel - _level;
        if (targetLevel >= 60 && i > 12)
        {
            ConfirmOn();
            _serialPort.Write("m");//Maxに持っていく命令を飛ばす
            _level = 60;
        }
        else if (i > 0)
        {
            ShakeUp(i);
        }
        else if (i < 0)
        {
            ShakeDown(-i);
        }
    }

    public void ReadESPString(object data)
    {
        var text = data as string;
        Debug.Log(text);
    }

    public void OnoffChanger() {
        _serialPort.Write("s");
        _serialPort.Write("s");
    }
}
