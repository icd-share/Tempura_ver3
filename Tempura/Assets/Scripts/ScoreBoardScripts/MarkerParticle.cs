using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerParticle : MonoBehaviour
{
    /*
        パーティクルの発生源が白いマーカーを追尾する
    */

    //マーカーオブジェクトを_scoreMarkerに指定
    public GameObject _scoreMarker;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_markerPosにマーカーの位置情報を格納
        Vector3 _markerPos = _scoreMarker.transform.position;

        //パーティクルの発生源の位置をマーカーの位置に固定
        this.transform.position = _markerPos;
    }
}
