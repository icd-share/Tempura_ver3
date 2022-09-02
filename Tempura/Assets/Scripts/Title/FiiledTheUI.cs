using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FiiledTheUI : MonoBehaviour
{
    [SerializeField] private Image _okWhite;
    [SerializeField] private float changeTime;
    private float _totalTime;
    [SerializeField] private GestureStateTimer _gestureStateTimer;

    // Start is called before the first frame update
    void Start()
    {
        _totalTime = 0;
        
        //_okWhite.fillAmount = _totalTime / changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        _totalTime = _gestureStateTimer.GetTotalTime();
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            _totalTime  +=Time.deltaTime;
        }*/
        _okWhite.fillAmount = _totalTime / changeTime;
    }
}
