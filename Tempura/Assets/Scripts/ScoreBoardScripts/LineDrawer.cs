using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    白のマーカーの軌跡を描く
*/

public class LineDrawer : MonoBehaviour
{
    LineRenderer _line;

    //頂点の数
    int _vertexCount;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    //Fixed Timestampの値ごとにUpdateを呼ぶ
    void FixedUpdate()
    {
        //vertexCountを1ずつ増加
        _vertexCount += 1;

        _line.positionCount = _vertexCount;

        _line.SetPosition(_vertexCount - 1, transform.position);
    }
}
