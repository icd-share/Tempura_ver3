using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerMoveManager : MonoBehaviour
{
    public GameObject _marker;
    public RectTransform _parentPanel;

    //取得したデータ数
    public int _numOfData;

    //折れ線の頂点間の距離
    private float _disVertex;

    //動き始めるまでの時間
    public float _deltaTime;

    //マーカーの開始および終了x座標
    private float _startMarkerX, _endMarkerX;

    //マーカーの動き始めるトリガー用スターター
    private bool _starter;

    //複製したマーカーを格納する変数
    public static GameObject _cloneMarker;
   
    void Start()
    {
        //折れ線の頂点間の距離を計算
        _disVertex = 12.0f / _numOfData;

        //マーカーのスタート位置を演算
        _startMarkerX = CalculateMarkerPosition(_numOfData);

        //マーカーのゴール位置を演算
        _endMarkerX = _startMarkerX + _disVertex * (float)_numOfData;

        //Debug.Log("データ数=" + _numOfData + ", 幅=" + _disVertex + ", スタート位置=" + _startMarkerX + ", ゴール位置=" + _endMarkerX);

        //MoveMarkerメソッドをコルーチンに設定
        StartCoroutine("MoveMarker");

        //マーカーを指定する座標はワールド座標(Canvasから一度出して確認)
        //スタート位置にマーカーを生成
        _cloneMarker = Instantiate(_marker, new Vector3(_startMarkerX, -2.7f, 9.4f), Quaternion.Euler(90f, 0f, 0f), _parentPanel);

        _cloneMarker.name = "RealMarker";
    }

    // Update is called once per frame
    void Update()
    {
        //スターターがオンになったら
        if(_starter == true){

            //生成したマーカーの位置を取得
            Vector3 _markerPos = _cloneMarker.transform.position;

            //マーカーがゴール位置より大きいとき
            if(_markerPos.x >= _endMarkerX) 
            {
                //マーカーをゴール位置に固定
                _markerPos.x = _endMarkerX;
                //Debug.Log("現在位置G=" + _cloneMarker.transform.position.x);//いったんけしました．
            }

            //マーカーがゴール位置に達していないとき
            else
            {
                //マーカーを移動させる
                _cloneMarker.transform.position += new Vector3(0.1f, 0f, 0f);
                Debug.Log("現在位置=" + _cloneMarker.transform.position.x);
            }
        }
    }

    float CalculateMarkerPosition(int num)
    {
        //markerの位置情報を_startPositionに格納
        Vector3 _startPosition = transform.position;

        //取得したデータ数が偶数個
        if(_numOfData % 2 == 0)
        {
            //マーカーのスタート位置を決定(3.5fはウィンドウの中央x)
            _startPosition.x = 0.0f - _disVertex * (_numOfData / 2);
        }

        //取得したデータ数が奇数個
        else
        {
            _startPosition.x = 0.0f - _disVertex * (float)_numOfData / 2;
        }

        return _startPosition.x;
    }

    IEnumerator MoveMarker()
    {
        yield return new WaitForSeconds(_deltaTime);

        _starter = true;
    }

    public void MarkerMove()
    {
        _disVertex = 12.0f / _numOfData;

        //マーカーのスタート位置を演算
        _startMarkerX = CalculateMarkerPosition(_numOfData);

        //マーカーのゴール位置を演算
        _endMarkerX = _startMarkerX + _disVertex * (float)_numOfData;

        Debug.Log("データ数=" + _numOfData + ", 幅=" + _disVertex + ", スタート位置=" + _startMarkerX + ", ゴール位置=" + _endMarkerX);

        //MoveMarkerメソッドをコルーチンに設定
        StartCoroutine("MoveMarker");

        //マーカーを指定する座標はワールド座標(Canvasから一度出して確認)
        //スタート位置にマーカーを生成
        _cloneMarker = Instantiate(_marker, new Vector3(_startMarkerX, -2.7f, 9.4f), Quaternion.Euler(90f, 0f, 0f), _parentPanel);

        _cloneMarker.name = "RealMarker";
    }
}
