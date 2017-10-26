using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACTransit.UI
{
    public class interp_co : MonoBehaviour
    {
        #region Data

        public bool runOnce = true;
        [Tooltip("target of where to move it to")]
        public Transform target;
        [Tooltip("how 'far' you want the camera to move/final distance from target; less than 1 is good; ")]
        public float zoom = .5f;
        //public float totalTime = 5f;

        [Tooltip("start angle of the curve controlling the rotation")]
        public float startAngle = 75f;
        [Tooltip("final angle of the curve controlling the rotation")]
        public float finalAngle = 0f;

        //Lerp Variables
        [Tooltip("How fast should it interpolate")]
        public float speed;
        private float startTime;
        private float journeyLength; 
        private bool isInterComplete; //checks if the interpolation is completed

        private AnimationCurve pitchCurve; //how rotation along x should vary w/zoom
        private AnimationCurve distanceCurve; //how far camera is along chosen pitch based on zoom

        #endregion

        #region Engine Functions

        void Start() //setting up the curvse that control the rotation & "curving" position of the movement
        {
            //interpolation variables
            startTime = Time.time;
            journeyLength = Vector3.Distance(transform.position, target.position);
            
            //curve for the rotation of 
            pitchCurve = AnimationCurve.EaseInOut(0.0f, finalAngle, 1.0f, startAngle);

            //exponential curve for distance = more accurate zoom control the closer you are
            Keyframe[] ks = new Keyframe[2];
            ks[0] = new Keyframe(0, 0.5f); //offset by .5 at 0
            ks[0].outTangent = 0; //tangent of curve as you leave this point.  flat.

            ks[1] = new Keyframe(1, 60);
            ks[1].inTangent = 90;

            distanceCurve = new AnimationCurve(ks); //make curve w/the stuff we just did: makes an exponential curve

            //interpolate
            StartCoroutine(interMovement(target, journeyLength, speed));
        }
        #endregion

        #region Game Functions
        void InterTransform(Transform initialPos, Transform inTarget, float inPerc, float inSpeed) //where the interpolation magic happens
        {
            //calculating x-rotation based on current zoom:
            float targetRotX = pitchCurve.Evaluate(zoom);
            float targetRotY = inTarget.rotation.eulerAngles.y;

            //target roation as quaternion; z to 0 so we don't roll camera
            Quaternion targetRot = Quaternion.Euler(targetRotX, targetRotY, 0.0f);

            //how far in the current viewing thing do we want the camera to go back?
            Vector3 offset = Vector3.forward * distanceCurve.Evaluate(zoom);

            //subtract this offset based on current camera rotation.
            Vector3 targetPos = inTarget.position - targetRot * offset;

            transform.position = Vector3.Lerp(initialPos.position, targetPos, (inPerc * Time.deltaTime) * inSpeed);  
            transform.rotation = Quaternion.Slerp(initialPos.rotation, targetRot, (inPerc * Time.deltaTime) * inSpeed);
        }

        //New Coroutine
        IEnumerator interMovement(Transform target, float journeyLength, float speed = 1)
        {
            #region DeltaTimeMethod
            /*
            Transform initPos = transform;
            float elapsedTime = 0.0f;
            elapsedTime += Time.deltaTime;

            float SqrRemDistanceMag = (transform.position - target.position).sqrMagnitude;
            while (SqrRemDistanceMag > float.Epsilon)
            {
                elapsedTime += Time.deltaTime;
                float percentage = elapsedTime / journeyLength;

                transform.position = Vector3.Lerp(initPos.position, target.position, percentage);
                transform.rotation = Quaternion.Slerp(initPos.rotation, target.rotation, percentage);
                SqrRemDistanceMag = (transform.position - target.position).sqrMagnitude;
                yield return new WaitForEndOfFrame();
            }
            */
            #endregion
             Transform initPos = transform;
             float percTracker = 0.0f;
             
            //Loop, If it reaches 1 then interpolation is complete
             while (percTracker < 1.0f ) 
             {
                 float timeSinceStarted = (Time.time - startTime) * speed;
                 float percentage = (timeSinceStarted / journeyLength);
                 percTracker = Mathf.Clamp01(percentage);
                 InterTransform(initPos, target, percTracker, speed);
                 //Debug.Log(percentage);
                 yield return new WaitForEndOfFrame();
             }
             
            IsInterComplete = true;
        }

        //Old Coroutine
        /*IEnumerator interMoveCo(Transform target, float journeyLength, float speed = 2) //lerping in a coroutine!  yay!
        {
            float startTime = Time.time;
            Transform initPos = transform;
            while (Time.time < startTime + journeyLength)
            {
                float timeSinceStarted = (Time.time - startTime);
                float percentageComplete = timeSinceStarted / journeyLength;
                yield return null;
            }
            IsInterComplete = true;
        }*/
        
        #endregion

        #region Helper Functions

        public bool IsInterComplete
        {
            set
            {
                isInterComplete = value;
            }
            get
            {
                return isInterComplete;
            }
        }

        #endregion
    }
}
