using UnityEngine;
using System.Collections;

public class dungeonCrawler_camera : MonoBehaviour {

    public Transform target; //reference to target
    float smooth = 5f;
    public float height = 7f;
    float zDistance = -1f;
    Vector3 newPosition;

    void Start()
    {
        newPosition = new Vector3(0, height, zDistance);
    }

	void LateUpdate()
    {
        transform.position = target.position + newPosition;
        transform.LookAt(target);
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * smooth);
    }
}
