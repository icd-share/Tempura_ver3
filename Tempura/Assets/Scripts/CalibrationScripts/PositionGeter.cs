using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGeter : MonoBehaviour
{
    [Header("CalibrationManagerをセット")]
    [SerializeField] private GameObject _calibrationManagerObject;
    [SerializeField] private CalibrationManager _calibrationManager;
    
    [Header("どちらの向きを取得するかを選択")]
    [SerializeField] private bool _isFinger = false;
    [SerializeField] private bool _isWrist = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _isWrist = !_isFinger;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFinger)
            this.transform.position = _calibrationManager.GetFingerPosition();
        else
            this.transform.position = _calibrationManager.GetWristPosition();
        
        this.transform.right = _calibrationManagerObject.transform.right;
        this.transform.up    = _calibrationManagerObject.transform.up;
        this.transform.forward = _calibrationManagerObject.transform.forward;
    }
}
