using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    static CheckPoint activePoint;
    static CheckPoint firstCheckPoint;

    //hero_Status playerStat;
    //public static ParticleEmitter activeEmitter;
    public static Light activeLight;

    public bool isActive = false;


	// Use this for initialization
	void Start () {
        firstCheckPoint = GameObject.Find("first_checkpoint").GetComponent<CheckPoint>(); //find the "first checkpoint"
        //set the actives
        activePoint = firstCheckPoint; 

        activeLight = activePoint.gameObject.transform.GetChild(0).GetComponent<Light>();
        gameObject.transform.GetChild(0).GetComponent<Light>().enabled = false;

        //make it active
        if (activePoint != this) { BeActive(); }
	}

    public CheckPoint getActive() { return activePoint; }

    void OnTriggerEnter()
    {
        if (activePoint != this)
        {
            activePoint.BeInactive();
            activePoint = this;
            activeLight = activePoint.gameObject.transform.GetChild(0).GetComponent<Light>();
            activePoint.BeActive();
        }
    }

	void BeActive() { activeLight.enabled = true; isActive = true; }

    void BeInactive() { activeLight.enabled = false; isActive = false; }

    static Vector3 getActivePosition()
    {
        return activePoint.transform.position;
    }
}
