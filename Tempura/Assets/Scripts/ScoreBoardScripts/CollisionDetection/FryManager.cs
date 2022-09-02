using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class FryManager : MonoBehaviour
{
    private float _totalTime;
    [SerializeField] private bool _isInTheOil=false;//手が油の中にあるか反映するフラグ
    [SerializeField] private bool _isOnThePlate = false;//揚げた手んぷらを皿に乗せたか判定するフラグ
    [SerializeField] private bool _isEnd = false; //最後の繰り返し防止用のフラグ
    [SerializeField] private bool _isFryed = false;//手を1回でも油から出したことを判定するフラグ
    [SerializeField] private bool _isForAudioOnce = false;//揚がった後の音を一度だけ出力するためのフラグ
    [SerializeField] private bool _isMarkerMove = false;//マーカーを動かすフラグ
    [SerializeField] private bool _isParticle = false;
    [SerializeField] private bool _isbat = false;
    [SerializeField] private bool _isVR=false;
    [SerializeField] private bool _isKoromo = false;
    [SerializeField] private ColorChanger _colorChanger;//手の色変えるための関数
    [SerializeField] private ShakeChanger _shakeChanger;//手の振動変えるための関数
    [SerializeField] private HandCoordinate _handposition; //手の位置を計測するための関数
    [SerializeField] private AudioChanger _audioChanger;
    [SerializeField] private ParticleManager _particleManager;
    [SerializeField] private LiquidOilManager _liquidOilManager;
    [SerializeField] private float _targetTime = 30f;
    [SerializeField] private RandomScoreManager _displayRoulette;
    [SerializeField] private FinalScoreManager _CalculateFinalScore;
    [SerializeField] private ColorChangerVR _colorChangerVR;
    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private int _playerScore;
    [SerializeField] private TimeDisplay _timeDisplay;
    [SerializeField] private GameObject _ScoreBoard;
    [SerializeField] private CalibrationManager _calibrationManager;
    public ViveHandTracking.ModelRenderer _handtracking;
    [SerializeField] private bool _isDebugScore;
    void Start()
    {
        _totalTime = 0;

        _isOnThePlate=false;
        _ScoreBoard.SetActive(false);//Canvasを非表示にする．
       
    }

    // Update is called once per frame
    void Update()
    {
        _isInTheOil = _collisionManager.isInTheOil();
        _isOnThePlate = _collisionManager.isOnThePlate();
        _isFryed = _collisionManager.isFryed();
        _isbat = _collisionManager.isBat();
        _isKoromo = _collisionManager.isKoromo();
        if(_isDebugScore)
        _isKoromo = true;

        
        if(_calibrationManager.GetCalibration() && !_isEnd && !_isFryed)
        {
            _colorChangerVR.KoromoColorChanger();

        }

        if (_isInTheOil &&!_isEnd &&_isKoromo &&_calibrationManager.GetCalibration())
        {
            //Debug.Log("ぶつかった");
            _totalTime += Time.deltaTime; 
            _liquidOilManager.InTheHandOil();
            _colorChanger.colorchanger(_totalTime,_targetTime);//手の変化用関数に時間を渡す
            _shakeChanger.shakechanger(_totalTime,_targetTime);//振動変化用関数に時間を渡す
            _handposition.handposition(_totalTime);//手の位置測定用関数に時間を渡す
            _audioChanger.audiochanger(_totalTime,_targetTime);//音の変化用関数に時間を渡す
            if(!_isParticle)
                _particleManager.OnParticle(_targetTime);
            _isParticle = true;
            _particleManager.ParticleColor(_totalTime,_targetTime);
            if(_isVR)
                _colorChangerVR.colorchanger(_totalTime,_targetTime);
        }
        if (_isInTheOil &&!_isEnd&&_isForAudioOnce && _calibrationManager.GetCalibration())//天ぷら２度付け条件
        {
            Debug.Log("ok");
            _isForAudioOnce = false;
            _audioChanger.audioNidoduke();//２度付けの音を出す．
        }
        if(!_isInTheOil && _isFryed && !_isEnd && !_isForAudioOnce && _calibrationManager.GetCalibration())//天ぷらを油から出したとき
        {
            _audioChanger.stopfryaudio();
            _audioChanger.audioafter(_totalTime);
            _isForAudioOnce = true;
            _liquidOilManager.normalOil();
        }

        if (_isOnThePlate && _isFryed && !_isEnd && _calibrationManager.GetCalibration())//天ぷらを皿のうえに置いたとき
        {
            Debug.Log("GOOOD");
            _ScoreBoard.SetActive(true);
            _handposition.allscore();
            _timeDisplay.timeDisplay(_totalTime);
            _playerScore=_CalculateFinalScore.CalculateFinalScore(_totalTime,_targetTime);////最終スコアの点数計算
            _displayRoulette.RandomScoreVision();   //スコアルーレットの開始
            _CalculateFinalScore.FinalScoreVision(_playerScore);//最終スコアの表示
            //マーカーを動かすフラグオン
            //Debug.Log("NumberofDate"+_handposition.numberofscore());
            //_isOnThePlate = false;
            _isEnd = true;
            _handtracking.enabled = false;

        }
        if (_isMarkerMove)
        {
            //マーカーを動かす関数を呼ぶ．
            //ゴールに達したか判定．
            //
        }
    }

    
    
    //todo("音の調整")
    

}
