using UnityEngine;
using System.Collections;

public class camera_follow : MonoBehaviour {

    public Transform target;
    Vector3 charaForward;
    public float smoothing = 5f; //speed that camera follows

    Vector3 offset;

	// Use this for initialization
	void Start () {
        //initial offset
        offset = transform.position - target.position;
	}
	
	
	void FixedUpdate () {
        //charaForward = target.transform.forward;
        //charaForward.x = 45;
        Vector3 targetCamPos = target.position + offset;
        //transform.forward = Vector3.Lerp(transform.forward, charaForward, smoothing * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
