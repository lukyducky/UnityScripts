using UnityEngine;
using System.Collections;

public class enemy_waypoint : MonoBehaviour {

    public float accel = .8f; //how quickly speed limit is reached
    public float inertia = 0.9f; //lower val = quicker stops; 1 = no stops; >1 = speed up
    public float speedLimit = 10f;
    public float minSpeed = 1f; //speed when slow() will tell it to stop.
    public float stopTime = 1f; //how long to pause between slow() and accell()

    float currentSpeed = 0;

    int funState = 0;
    bool accelState;
    bool slowState;

    Transform waypoint;
    public float rotationDamping = 6.0f; //speed to face waypoints
    public bool smoothRotation = true;
    public Transform[] waypoints;
    int WPindex;

	// Use this for initialization
	void Start ()
    {
        funState = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (funState == 0)
        {
            Accell();
        }
        if (funState == 1)
        {
            StartCoroutine(Slow());
        }
        waypoint = waypoints[WPindex];
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "waypoint")
        {

        } 
        funState = 1;
        WPindex++;
        if (WPindex >= waypoints.Length)
        {
            WPindex = 0;
        }
    }

    void Accell()
    {
        if (accelState == false)
        {
            accelState = true;
            slowState = false;
        }
        if (waypoint){
            if (smoothRotation)
            {
                transform.LookAt(waypoint);
                transform.rotation = Quaternion.Slerp(transform.rotation, waypoint.rotation, Time.deltaTime * rotationDamping);
            }
        }
        currentSpeed = currentSpeed + accel * accel;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);

        if (currentSpeed >= speedLimit)
        {
            currentSpeed = speedLimit;
        }
    }

    IEnumerator Slow()
    {
        if (slowState == false)
        {
            accelState = false;
            slowState = true;
        }
        currentSpeed = currentSpeed * inertia;
        transform.Translate(0, 0, Time.deltaTime * currentSpeed);

        if (currentSpeed <= minSpeed)
        {
            currentSpeed = 0.0f;
            yield return new WaitForSeconds(stopTime);
            funState = 0;
        }
    }
}
