using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasePositionDetactor : MonoBehaviour
{
    [SerializeField] private GameObject _tracker;
    [SerializeField] private GameObject _offseter;
    [SerializeField] private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = _offseter.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        /*
            _offset.x = -transform.localScale.x / 2;
            _offset.y = 0;
            _offset.z = 2 * transform.localScale.x;
        */
            this.transform.position = _tracker.transform.position + _offset;
            this.transform.rotation = _tracker.transform.rotation;
            
            /*
            this.transform.right = _tracker.transform.right;
            this.transform.up = _tracker.transform.up;
            this.transform.forward = _tracker.transform.forward;
            */

        }
}
