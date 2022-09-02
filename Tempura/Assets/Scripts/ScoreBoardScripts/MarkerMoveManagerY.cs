using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerMoveManagerY : MonoBehaviour
{
    public float _deltaTime;

    private bool _starter = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MoveMarkerY");
    }

    // Update is called once per frame
    void Update()
    {
        if(_starter == true)
        {
            MarkerMoveManager._cloneMarker.transform.position += new Vector3(0f, 0.1f, 0f);

            //Debug.Log("y座標= " + MarkerMoveManager._cloneMarker.transform.position.y); //板倉いったん消しました．
        }
    }

    IEnumerator MoveMarkerY()
    {
        yield return new WaitForSeconds(_deltaTime);

        _starter = true;
    }
}
