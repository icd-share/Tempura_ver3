using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColorChange : MonoBehaviour
{
    public GameObject _handUI;

    private SpriteRenderer _mesh;
    private bool _fade = true;

    [SerializeField] private CalibrationManager _calibrationManager;

    void Start()
    {
        _mesh = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(_fade == true)
        {
            _mesh.material.color = _mesh.material.color - new Color32(0,0,0,2);
            Debug.Log("へる " + _mesh.material.color.a);

            if(_mesh.material.color.a < 0)
            {
                _fade = false;
            }
        }

        else
        {
            _mesh.material.color = _mesh.material.color + new Color32(0,0,0,2);
            Debug.Log("ふえる" + _mesh.material.color.a);

            if(_mesh.material.color.a > 1)
            {
                _fade = true;
            }
        }

        if(_calibrationManager.GetCalibration())          
        {
            _handUI.SetActive(false);
        }
    }
}
