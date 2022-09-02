using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //第1UI
    public GameObject _handUI;
    public GameObject _leftUI;
    public GameObject _rightUI;
    public GameObject _rightArrayUI;

    //第2UI
    public GameObject _nabeUIIn;
    public GameObject _handUIIn;

    //第3UI
    public GameObject _nabeUIOut;
    public GameObject _handUIOut;

    //第4UI
    public GameObject _messageUI;
    public GameObject _leftArrayUI;

    private bool _isCalibOK = false;

    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private CalibrationManager _calibrationManager;
    //[SerializeField] private HandUIMove3 _UImove3;

    // Start is called before the first frame update
    void Start()
    {
        //第2～4UIをオフ
        _nabeUIIn.SetActive(false);
        _handUIIn.SetActive(false);

        _nabeUIOut.SetActive(false);
        _handUIOut.SetActive(false);

        _messageUI.SetActive(false);
        _leftArrayUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //キャリブレーションが終わったら
        if(_calibrationManager.GetCalibration() && _isCalibOK == false)
        {
            //第1UIをオフ
            _handUI.SetActive(false);
            _leftUI.SetActive(false);
            _rightUI.SetActive(false);
            _rightArrayUI.SetActive(false);

            //第2UIをオン
            _nabeUIIn.SetActive(true);
            _handUIIn.SetActive(true);

            _isCalibOK = true;
        }

        //鍋に手を入れたとき
        if(_collisionManager.isInTheOil() == true)
        {
            //第2UIをオフ
            _nabeUIIn.SetActive(false);
            _handUIIn.SetActive(false);

            //第3UIをオン
            _nabeUIOut.SetActive(true);
            _handUIOut.SetActive(true);
        }

        //鍋から手を出した時
        if(_collisionManager.isInTheOil() == false && _collisionManager.isFryed() == true)
        {
            //第3UIをオフ
            _nabeUIOut.SetActive(false);
            _handUIOut.SetActive(false);

            //第4UIをオン
            _messageUI.SetActive(true);
            _leftArrayUI.SetActive(true);
        }

        //皿に手を載せたとき
        if(_collisionManager.isOnThePlate())
        {
            //第4UIをオフ
            _messageUI.SetActive(false);
            _leftArrayUI.SetActive(false);
        }
    }
}
