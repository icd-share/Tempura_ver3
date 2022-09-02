using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestureStateTimer : MonoBehaviour
{
    private float _totalTime;
    private int _state;
    //[SerializeField] private GameObject _targetObject;
    private  ViveHandTracking.Sample.GestureStateChacker _scGestureStateChacker;
    private  SceneChanger _script_SceneChanger;
    public string _sceneName;

    void Start()
    {
        _totalTime = 0.0f;
        _scGestureStateChacker = GetComponent<ViveHandTracking.Sample.GestureStateChacker>();
    }

    // Update is called once per frame
    void Update()
    {
        _state = _scGestureStateChacker.ReturnState();
        if(_state > 0)
            _totalTime += Time.deltaTime;
        else if(_totalTime < 0.0f)
            _totalTime = 0.0f;
        else  
            _totalTime -= Time.deltaTime;
        
        if (_totalTime > 3.0){
            SceneChanger();
        }
            
    }

    void SceneChanger(){
        SceneManager.LoadScene(_sceneName);
    }

    public float GetTotalTime(){
        return _totalTime;
    }
}
