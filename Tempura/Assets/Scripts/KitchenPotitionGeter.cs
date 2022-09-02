using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPotitionGeter : MonoBehaviour
{
    [SerializeField] private GameObject _resoursePosition;
    public Vector3 dig ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _resoursePosition.transform.position;
        this.transform.rotation = _resoursePosition.transform.rotation;
        /*
        this.transform.right = _resoursePosition.transform.right * dig.x;
        this.transform.up = _resoursePosition.transform.forward * dig.y;
        this.transform.forward = _resoursePosition.transform.up * dig.z;
        //this.transform.rotation = _resoursePosition.transform.rotation;*/
    }
}
