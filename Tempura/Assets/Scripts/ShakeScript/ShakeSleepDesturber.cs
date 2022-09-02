using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeSleepDesturber : MonoBehaviour
{
    [SerializeField] private SerialPortUtility.SerialPortUtilityPro _serialPort = null;
    [SerializeField] private float _onoffSpan = 10f;

    private float _time = 9f;

    // Update is called once per frame
    void Update()
    {
        if (!_isOn)
            _time += Time.deltaTime;

        if (_time > _onoffSpan && !_isOn) {
            _time = 0;
            OnoffChanger();
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
