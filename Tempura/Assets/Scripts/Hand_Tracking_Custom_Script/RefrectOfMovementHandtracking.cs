using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ViveHandTracking.Sample
{

    class RefrectOfMovementHandtracking : MonoBehaviour
    {
        public GameObject TargetObject = null;
        protected bool skeletonRotation = true;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            if (!skeletonRotation) yield break;
            while (GestureProvider.Status == GestureStatus.NotStarted) yield return null;
            if (GestureProvider.HaveSkeleton) TargetObject.transform.localRotation = Quaternion.Euler(-30, 0, 0);
        }


        // Update is called once per frame
        protected virtual void Update()
        {
            var hand = GestureProvider.RightHand;
            if (hand == null)
            {
                //TargetObject.SetActive(false);
                return;
            }

            TargetObject.transform.position = hand.position;
            TargetObject.transform.rotation = hand.rotation;
            TargetObject.SetActive(true);
        }
    }

}