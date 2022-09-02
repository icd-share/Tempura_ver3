using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDetactor : MonoBehaviour
{
	[SerializeField] private GameObject _tracker;
    [SerializeField] private GameObject _offseter;
    [SerializeField] private Vector3 _offset ;

    // Start is called before the first frame update
    void Start()
    {
        _offset = _offseter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _tracker.transform.position - _offset;
        this.transform.rotation = _tracker.transform.rotation;
    }
}
