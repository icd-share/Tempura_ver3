using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDLocomotion : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Vector3 moving, latestPos;
    [SerializeField] private float _speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        MovementControll();
        Movement();
    }

    void FixedUpdate()
    {
        RotateToMovingDirection();
    }
    void MovementControll()
    {
        //斜め移動と縦横の移動を同じ速度にするためにVector3をNormalize()する。
        moving = new Vector3(0, Input.GetAxisRaw("Vertical"),Input.GetAxisRaw("Horizontal") );
        moving.Normalize();
        moving = moving * _speed;
    }

    public void RotateToMovingDirection()
    {
        Vector3 differenceDis = new Vector3(0,  transform.position.y,transform.position.x) - new Vector3(0,  latestPos.y,latestPos.x);
        latestPos = transform.position;
        //移動してなくても回転してしまうので、一定の距離以上移動したら回転させる
        
    }

    void Movement()
    {
        rb.velocity = moving;
    }
}
