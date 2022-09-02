using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    点数に応じたコメント評価を表示
*/

public class CommentManager : MonoBehaviour
{
    //最後の点数をGameObjectに指定
    public GameObject _finalScore;

    public float _showCommentTime;

    // Start is called before the first frame update
    void Start()
    {
        //DisplayCommentをコルーチンに設定
        StartCoroutine("DisplayComment");
    }

    IEnumerator DisplayComment()
    {

        //DisplayTimeだけ非表示のまま待機
        yield return new WaitForSeconds(_showCommentTime);


        //最後の点数をInt型で取得
        int _finalScoreInt = Int32.Parse(_finalScore.GetComponent<Text>().text);

        //取得した点数が90点以上ならgreat表示
        if(_finalScoreInt >= 96)
        {
            gameObject.GetComponent<Text>().text = "You Are GOD Tempurer…";
        }

        if(_finalScoreInt >= 90 && _finalScoreInt < 96)
        {
            gameObject.GetComponent<Text>().text = "Unbelievable!!!";
        }

        if(_finalScoreInt >= 80 && _finalScoreInt < 90)
        {
            gameObject.GetComponent<Text>().text = "Wonderful!!";
        }

        if(_finalScoreInt >= 70 && _finalScoreInt < 80)
        {
            gameObject.GetComponent<Text>().text = "Great!";
        }

        if(_finalScoreInt < 70)
        {
            gameObject.GetComponent<Text>().text = "Nice!";
        }
    }
}
