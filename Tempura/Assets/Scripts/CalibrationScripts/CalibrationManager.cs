using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationManager : MonoBehaviour
{
    [Header("トラッカー")] 
    public GameObject _trackerHand;
    public GameObject _trackerCase;

    [Header("CaseCollisionをセット")]
    [SerializeField] CollisionManager _collisionManager;
    /*
    [SerializeField] private GameObject _caseCollisionObject;
    [SerializeField] private CaseCollision _caseCollision;
    */


    [Header("トラッカー諸変数")] 
    [SerializeField] private float _sizeOfTrackerCase = 0;
    [SerializeField] private float _sizeOfTrackerHand = 0;
    
    //トラッカーと計算結果の位置
    private Vector3 _positionHand;
    private Vector3 _positionCase;
    private Vector3 _positionFinger;
    private Vector3 _positionWrist;
    public float _handLen;

    private Vector3[] _positionHandArray = new Vector3[40];
    [SerializeField] private float _borderSize = 0.01f;
    [SerializeField] private float _borderSec = 2.0f;
    private float _time;

    //キャリブレーション計算結果
    private Vector3 _calcForWrist;
    private Vector3 _calcForFinger;

    private bool _isCalibrated = false;
    private bool _isCollision = false;
    private bool _isKeep = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //トラッカーの位置の取得
        _positionHand = _trackerHand.transform.position;
        _positionCase = _trackerCase.transform.position;


        this.transform.right = _trackerHand.transform.right;
        this.transform.up    = _trackerHand.transform.forward;
        this.transform.forward = -_trackerHand.transform.up;

        _isCollision = _collisionManager.isBat();
        _time += Time.deltaTime;

        if (_time > 0.1f)
        {
            _time = 0;
            _positionHandArray[0] = _positionHand;

            for (int i = 39; i > 0; i--)
            {
                _positionHandArray[i] = _positionHandArray[i - 1];
            }
            
            _isKeep = ChackFreeze();
        }

            if (_isCalibrated)
        {
            _positionWrist = _positionHand + _calcForWrist;
            _positionFinger = _positionHand + _calcForFinger;
        }

        if ((_isCollision && _isKeep) || Input.GetKeyDown(KeyCode.Space))//デバックではSpaceキーでキャリブレーション
        {
            Calibration();
        }
        
    }

    private void Calibration()
    {
        //トラッカーの位置から手首の位置の計算 手首のトラッカーの位置が手首の位置になるが，高さのみはケースの位置に補正
        Vector3 tempPositionWrist = new Vector3(_positionHand.x, _positionCase.y, _positionHand.z);

        //手首のトラッカーのサイズを減算 その際、トラッカーのサイズはナナメであることを考慮
        float trackerDia = _sizeOfTrackerHand * Mathf.Cos((_trackerHand.transform.eulerAngles.x + 90f) * 2f * Mathf.PI / 180f);
        Vector2 a = new Vector2(_positionHand.x, _positionHand.z);
        Vector2 b = new Vector2(_positionCase.x, _positionCase.z);
        Vector2 z = b - a;
        float sizez = z.magnitude;
        
        tempPositionWrist.x = tempPositionWrist.x + (z.x / sizez * trackerDia);
        tempPositionWrist.z = tempPositionWrist.z + (z.y / sizez * trackerDia);
        Debug.Log(trackerDia);
        
        //指先を表す座標
        Vector3 tempPositionFinger = _positionCase;
        
        //ケースにつけたトラッカーのサイズを減算
        tempPositionFinger.x = tempPositionFinger.x - (z.x / sizez * _sizeOfTrackerCase);
        tempPositionFinger.z = tempPositionFinger.z - (z.y / sizez * _sizeOfTrackerCase);
        
        //手首と指先の位置の確定
        _positionWrist = tempPositionWrist;
        _positionFinger = tempPositionFinger;

        _calcForWrist = _positionWrist - _positionHand;
        _calcForFinger = _positionFinger - _positionHand;

        _handLen = Vector3.Distance(_calcForWrist, _calcForFinger);
        if (_handLen > 0.5f || _handLen < 0.05f) //キャリブレーション失敗（予測）
        {
            return;
        }

        Debug.Log("_calcForFinger  " + _calcForFinger);
        Debug.Log("_calcForWrist  " + _calcForWrist);
        Debug.Log("_handLen  " + _handLen);

        _isCalibrated = true;
    }
    private bool ChackFreeze(){
        for (int i = 1; i < _borderSec / 0.1f; i++){
            if (Mathf.Abs(_positionHandArray[0].x - _positionHandArray[i].x ) > _borderSize) //直近２秒間のx,y,zについて、1cm以上動いていないかを検査
                return false;
            if (Mathf.Abs(_positionHandArray[0].y - _positionHandArray[i].y ) > _borderSize)
                return false;
            if (Mathf.Abs(_positionHandArray[0].z - _positionHandArray[i].z ) > _borderSize)
                return false;
        }
        return true;
    }


    public Vector3 GetWristPosition()
    {
        if (_isCalibrated)
        {
            return _positionWrist;
        }
        //TODO:キャリブレーション前も補正する
        return _positionHand - new Vector3(0, 0.05f, 0);
    }
    public Vector3 GetFingerPosition()
    {
        if (_isCalibrated)
        {
            return _positionFinger;
        }
        //TODO:キャリブレーション前も補正する
        return _positionHand;
    }

    public float GetHandLen()
    {
        if (_isCalibrated)
        {
            return _handLen;
        }
        return 0.16f; //未キャリブレーションの暫定値
    }

    public bool GetCalibration()
    {
        return _isCalibrated;
    }

    public float GetLength(){
        return _handLen;
    }
}
