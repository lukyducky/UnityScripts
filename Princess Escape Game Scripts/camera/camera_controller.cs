using UnityEngine;
using System.Collections;

[AddComponentMenu("Player/CameraController")]

public class camera_controller : MonoBehaviour {

    public Transform target; //chara's transform component

    public float distance = 1.0f; //distance x and y from target
    public float height = 1.0f; //distance y from target

    //speed controls for the camera, to follow the moving thing
    //so that we can adjust the speeds of variables
    public float heightDamping = 2.0f;
    public float rotationDamping = .1f;
    public float distanceDampingX = 0.1f;
    public float distanceDampingZ = 0.1f;

    //camera controls to look at target
    public float camSpeed = 2.0f;
	

	void LateUpdate () {
        //check to makesure we've assigned in inspector
        if (!target) { Debug.Log("no target found in camera_controller"); return; }

        else
        {
            //calculate current rotation angles, posistions, and where to move camera
            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;
            float currentDistanceZ = transform.position.z;
            float currentDistanceX = transform.position.x;

            //calculate wanted transforms
            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight = target.position.y + height;
            float wantedDistanceZ = target.position.z - distance;
            float wantedDistanceX = target.position.x - distance;

            //get new transforms
            float newHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            float newRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            float newPositionZ = Mathf.Lerp(currentDistanceZ, wantedDistanceZ, distanceDampingZ * Time.deltaTime);
            float newPositionX = Mathf.Lerp(currentDistanceX, wantedDistanceX, distanceDampingX * Time.deltaTime);

            Quaternion newRotation = Quaternion.Euler(0, newRotationAngle, 0);

            Vector3 transformVect = transform.position;

            transformVect -= newRotation * Vector3.forward * distance;
            transformVect.x = newPositionX;
            transformVect.y = newHeight;
            transformVect.z = newPositionZ;
            transform.position = transformVect;

            LookAtTarget();
        }
	}


    void LookAtTarget()
    {
        Quaternion camRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, camRotation, Time.deltaTime * camSpeed);

    }

}
