using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ViveHandTracking.Sample
{
    public class GestureStateChacker : MonoBehaviour
    {
        // Start is called before the first frame update
        //public GameObject _targetObject;
        //private float _totalTime;
        private int state = 0;

        void Start()
        {
            //TargetObject.SetActive(false);
            //this._state = 0;
        }

        void Update()
        {
            //Debug.Log("Handstate = "+ _state);
            Debug.Log("Handstate = "+ this.state);
        }

        public void OnStateChanged(int state)
        {
            this.state = state;
            ;
            //GetComponent<RefrectOfMovementHandtracking>().enabled = (state > 0);
            /*
            if(state > 0)
                _totalTime += Time.deltaTime;
            else if(_totalTime < 0.0f)
                _totalTime = 0.0f;
            else  
                _totalTime -= Time.deltaTime;
            */
            //TargetObject.SetActive(state > 0);
        }

        public int ReturnState(){
            return this.state;
        }

    }
}