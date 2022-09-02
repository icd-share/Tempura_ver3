using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositionCalculater : MonoBehaviour
{
    [SerializeField] private CollisionManager _collisionManager;
    [SerializeField] private GameObject _hand;

    [SerializeField] private float _span = 0.5f;
    [SerializeField] private float _borderM1 = 0.02f;
    [SerializeField] private float _borderM3 = 0.05f;

    private Vector3[] _positionHandArray = new Vector3[120];
    private int _i = 0;
    private float _time;
    private int _mScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_collisionManager.isInTheOil()){
            _time += Time.deltaTime;
            if(_time > _span && _i > 0 && _i < 120) {
                MoveChacker();//一定時間ごとにぶれの検査
                _i++;
                _time = 0;
            }
            else if (_time > 3.0f && _i == 0){
                _positionHandArray[0] = _hand.transform.position;
                _i = 1;
                _time = 0;
            }
        }
        else
            _time = 0;//油にいないときはリセット
    }

    public int GetMscore(){
        return _mScore;
    }

    private void MoveChacker(){
        _positionHandArray[_i] = _hand.transform.position;
        float dis = Vector3.Distance(_positionHandArray[_i], _positionHandArray[_i-1]);
        if (dis < _borderM1)
            return;
        else if (dis < _borderM3){
            _mScore -= 1;
            return;
        }
        else {
            _mScore -= 3;
        }       
        return;
    }
}
