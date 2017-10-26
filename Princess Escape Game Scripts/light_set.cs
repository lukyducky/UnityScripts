using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_set : MonoBehaviour {
    /// <summary>
    /// Used to turn off a grouped set of lights
    /// </summary>
    light_torch[] lights;
    public bool isOn = false;


	// Use this for initialization
	void Start () {
        lights = gameObject.GetComponentsInChildren<light_torch>();
        setLights(isOn);

    }


    public void setLights(bool inOn)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].GetComponentInChildren<Light>().enabled = inOn;
        }
    }
}
