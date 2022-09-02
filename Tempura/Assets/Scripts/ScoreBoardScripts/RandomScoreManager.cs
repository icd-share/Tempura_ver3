using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RandomScoreManager : MonoBehaviour
{
    public GameObject _scoreObject; 

    [SerializeField] private bool _startRoulette;
    [SerializeField] private float _rouletteTime;

    // Start is called before the first frame update
    void Start()
    {
        _startRoulette = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_startRoulette == true)
        {
            //2秒間のみルーレットスコアを表示(Destroyした後は参照しない)
            if(_scoreObject != null){

                //オブジェクトからTextコンポーネントを取得
                Text _scoreText = _scoreObject.GetComponent<Text> ();

                //Randomクラスのインスタンス生成
                var _randomNum = new System.Random();

                //0～99の乱数を取得
                int _preScoreNum = _randomNum.Next(0, 100);

                //乱数を表示
                _scoreText.text = _preScoreNum.ToString();
            }
        }
    }

    public void RandomScoreVision()
    {
        _startRoulette = true;
        Destroy(_scoreObject, _rouletteTime);
    }
}
