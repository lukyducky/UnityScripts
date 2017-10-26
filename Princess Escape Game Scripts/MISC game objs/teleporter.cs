using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour {
    /// <summary>
    /// a one-way TP.  in this case, going from lower to upper level; also enables/disables lights of corresponding levels
    /// </summary>
    //private GameObject input;
    private GameObject output; //the 'out' teleporter
    light_set upper;
    light_set lower;

	// Use this for initialization
	void Start () {
        output = GameObject.Find("TP_out");
        upper = GameObject.Find("upper_torches").GetComponent<light_set>();
        lower = GameObject.Find("lower_torches").GetComponent<light_set>();
	}

    void OnTriggerEnter(Collider other){
        StartCoroutine(wait(1.5f));
        other.transform.position = output.transform.position;
        lower.setLights(false);
        upper.setLights(true);
    }
    
    IEnumerator wait(float t)
    {
        yield return new WaitForSeconds(t);
    
    }

}
