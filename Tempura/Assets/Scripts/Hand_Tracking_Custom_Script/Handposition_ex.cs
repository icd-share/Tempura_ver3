using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handposition_ex : MonoBehaviour
{

    float up = 0.1f;
    float right = 0.1f;
 
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"up", false },
        {"down", false },
        {"right", false },
        {"left", false },
    };

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-1.939f, 1.308f, 0.239f);
    }

    // Update is called once per frame
    void Update()
    {
        move["up"] = Input.GetKey(KeyCode.UpArrow);
        move["down"] = Input.GetKey(KeyCode.DownArrow);
        move["right"] = Input.GetKey(KeyCode.RightArrow);
        move["left"] = Input.GetKey(KeyCode.LeftArrow);
    }

    void FixedUpdate()
    {
        if (move["up"])
        {
            transform.Translate(0f, 0f, up);
        }
        if (move["down"])
        {
            transform.Translate(0f, 0f, -up);
        }
        if (move["right"])
        {
            transform.Translate(right, 0f, 0f);
        }
        if (move["left"])
        {
            transform.Translate(-right, 0f, 0f);
        }
    }
}
