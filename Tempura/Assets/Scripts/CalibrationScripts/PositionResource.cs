using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResource : MonoBehaviour
{
    [SerializeField] private GameObject _tracker;
    [SerializeField] private bool _isFreeze = false;
    [SerializeField] private float _timeToFreeze = 6f;
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isFreeze)
        {
            //Trackerから位置取得
            _time += Time.deltaTime;

            this.transform.position = _tracker.transform.position;
            this.transform.rotation = _tracker.transform.rotation;

            this.transform.right = -_tracker.transform.right;
            this.transform.up = -_tracker.transform.forward;
            this.transform.forward = -_tracker.transform.up;
        }

        //一定時間経過後、位置取得を中止
        if (!_isFreeze && _time > _timeToFreeze)
        {
            _isFreeze = true;
        }

    }
}
