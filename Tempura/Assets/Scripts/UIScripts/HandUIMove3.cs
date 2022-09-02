using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUIMove3 : MonoBehaviour
{
    [SerializeField] private float _startPosY;    //手の開始y座標
    [SerializeField] private float _endPosY;      //手の終了y座標
    [SerializeField] private float _moveSpeed;    //手の移動速度

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MoveHand");
    }

    IEnumerator MoveHand()
    {
        while (true)
        {
            Vector3 _handPos = transform.localPosition;
            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");


            if (transform.localPosition.y >= _endPosY)
            {
                yield return new WaitForSeconds(0.5f);

                //Debug.Log("handpos1= " + transform.position.y);
                _handPos.y = _startPosY;
                transform.localPosition = _handPos;
            }

            else if (transform.localPosition.y < _endPosY)
            {
                //Debug.Log("handpos2= " + transform.position.y);
                transform.localPosition += new Vector3(0f, _moveSpeed, 0f);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
