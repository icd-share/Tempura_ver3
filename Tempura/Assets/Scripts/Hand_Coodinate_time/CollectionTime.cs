using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTime : MonoBehaviour
{
        public float countup;
  
        void OnCollisionEnter(Collision collision){
        
            //Debug.Log(collision.gameObject.name);

            if (collision.gameObject.name == "oil")
            {
                countup += Time.deltaTime;
            }
        
                Debug.Log("time="+countup);//–û‚ÉŽè‚ð“ü‚ê‚½Žž‚ÌŽžŠÔ
    }
    
}
