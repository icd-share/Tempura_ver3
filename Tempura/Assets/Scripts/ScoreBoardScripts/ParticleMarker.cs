using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMarker : MonoBehaviour
{
    void Update()
    {
        Vector3 _pos = transform.position;

        Debug.Log(_pos.x);

        _pos.x = GameObject.Find("RealMarker").transform.position.x;
    }
}
