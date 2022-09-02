using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ViveHandTracking.Sample
{
    public class ChangeActiveObject : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject TargetObject;
        public int count = 0;
        private int state = 0;


        void Start()
        {
            TargetObject.SetActive(false);

        }

        void Update()
        {
            Debug.Log("Handstate = "+ this.state);
            
        }

        public void OnStateChanged(int state)
        {
            this.state = state;
            GetComponent<RefrectOfMovementHandtracking>().enabled = (state > 0);
            TargetObject.SetActive(state > 0);
        }

    }
}