using UnityEngine;

public class wasd: MonoBehaviour
{
    
    private float _speed = 3.0f;

    private float _input_x;
    private float _input_z;

    void Update()
    {
        _input_x = Input.GetAxis("Horizontal");
        _input_z = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(_input_x, 0, _input_z);
        
        Vector3 direction = velocity.normalized;

        float distance = _speed * Time.deltaTime;
        Vector3 destination = transform.position + direction * distance;

        transform.LookAt(destination);
        transform.position = destination;
    }
}