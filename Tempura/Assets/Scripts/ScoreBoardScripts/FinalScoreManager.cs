using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

/*
    最終的な点数を受け取り、点滅させて表示
*/

public class FinalScoreManager : MonoBehaviour
{
    public GameObject _scoreObject;
    public GameObject _rankingObject;
    public HandPositionCalculater _handPositionCalculater;

    //最終スコア(一先ずUnity Editor上で指定)
    [SerializeField] private int _finalScore;
    [SerializeField] private int _ratioTime = 50;
    [SerializeField] private int _ratioBure = 50;

    //最終スコアを表示するまでの時間 / 点滅間隔時間
    public float _displayTime, _blinkingTime;

    private Text _scoreText, _rankingText;

    public bool _onOffFinalScore;

    //スコアのトップ3を格納する
    public int[] _scoreArray = {0, 0, 0};

    [SerializeField] public bool _isAtScoreScene;

    
    //
    public IEnumerator DisplayFinalScore()
    {
        //_deltaTimeだけ待機
        yield return new WaitForSeconds(_displayTime);

        //スコア表示
        _scoreObject.SetActive(true);

        //点数の点滅スイッチ
        _onOffFinalScore = true;

        for(int i = 1; i <= 6; ++i)
        {
            //点数が表示されたらblinkingtime後に非表示
            if(_onOffFinalScore == true)
            {
                yield return new WaitForSeconds(_blinkingTime);
                _scoreObject.SetActive(false);

                _onOffFinalScore = false;
            }

             //点数が非表示になったらblinkingtime後に表示
            else
            {
                yield return new WaitForSeconds(_blinkingTime);
                _scoreObject.SetActive(true);

                _onOffFinalScore = true;
            }
        }
    }

    //最終スコアを計算
    public int CalculateFinalScore(float totalTime,float _targetTime)     //引数：手を鍋に突っ込んでから皿に触れるまでの時間？ 板倉追記totaltimeとtargettimeを引用
    {
        //点数の一時格納用
        int _tempScore;
        int _timeScore;

        //プレイ時間とtargetTimeの時間差
        float _timeDiffrence = Mathf.Abs(totalTime - _targetTime);

        /*誤差基準の点数計算*/
        //誤差0～10sの場合
        if(_timeDiffrence <= 10.0f)
        {
            _timeScore = (int)Math.Round(100.0f - 3.0f * _timeDiffrence);
        }

        //誤差10～30sの場合
        else if(10.0f < _timeDiffrence && _timeDiffrence <= 30.0f)
        {
            _timeScore = (int)Math.Round(105.0f - 3.5f * _timeDiffrence);
        }

        //誤差30s以上の場合
        else
        {
            _timeScore =0;
        }

        int _bureScore = _handPositionCalculater.GetMscore() + _ratioBure + 5;
        _bureScore = _bureScore > _ratioBure? _ratioBure: _bureScore;
        _tempScore = _bureScore + _timeScore;
        _tempScore = _tempScore < 0? 0: _timeScore;

        DecideRanking(_tempScore);
        return _tempScore;
    }

    //frymanager
    public void FinalScoreVision(int score)
    {
        //オブジェクトからテキストコンポーネントを取得
        _scoreText = _scoreObject.GetComponent<Text>();


        _scoreText.text = score.ToString();

        //最初はスコア非表示
        _scoreObject.SetActive(false);

        //スコア表示関数をコルーチンに指定
        StartCoroutine("DisplayFinalScore");
    }

    //順位配列を決定・テキストを変更
    public void DecideRanking(int score)
    {
        //PlayerPrefsからスコアを獲得        
        _scoreArray[0] = PlayerPrefs.GetInt("1stSCORE", 0);
        _scoreArray[1] = PlayerPrefs.GetInt("2ndSCORE", 0);
        _scoreArray[2] = PlayerPrefs.GetInt("3rdSCORE", 0);

        /*ランキング配列の決定*/
        if(score >= _scoreArray[0])
        {
            _scoreArray[2] = _scoreArray[1];
            _scoreArray[1] = _scoreArray[0];
            _scoreArray[0] = score;
        }

        else if(score < _scoreArray[0] && score >= _scoreArray[1])
        {
            _scoreArray[2] = _scoreArray[1];
            _scoreArray[1] = score;
        }

        else if(score < _scoreArray[1] && score >= _scoreArray[2])
        {
            _scoreArray[2] = score;
        }

        //Playerprefsに保存
        PlayerPrefs.SetInt("1stSCORE", _scoreArray[0]);
        PlayerPrefs.SetInt("2ndSCORE", _scoreArray[1]);
        PlayerPrefs.SetInt("3rdSCORE", _scoreArray[2]);
        PlayerPrefs.Save();

        //オブジェクトからテキストコンポーネントを取得
        _rankingText = _rankingObject.GetComponent<Text>();

        //ランキングテキストを書き換え
        _rankingText.text = "・1st  " + _scoreArray[0] + "P\n・2nd  " + _scoreArray[1] + "P\n・3rd  " + _scoreArray[2] + "P";
    }
}
