using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTest : MonoBehaviour
{
    [SerializeField] private int A=1;

    public int P=1;

    public static int PS=1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("A"+A);
       Debug.Log("P"+P);
       Debug.Log("PS"+PS);
        
    }

    // Update is called once per frame
    void Update()
    {
        A++;
        P++;
        PS++;
        if (Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("A"+A);
            Debug.Log("P"+P);
            Debug.Log("PS"+PS);

        }
    }
}
