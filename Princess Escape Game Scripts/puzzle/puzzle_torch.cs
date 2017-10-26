using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle_torch : MonoBehaviour {
    /*
        puzzle torch script; works with other 'puzzle torches'
        torch must be connected to at least one other torch (connectTorch)
        >sets on/off of attached torch at start;
        >onTriggerEnter: sets on/off attached torch; sets connected torches to the opposites

         */

    public puzzle_torch connectTorch;
    public puzzle_torch connectTorch02;

    private AudioSource fireSound;

    ParticleSystem thisFire;
    Light torch;
    puzzle_behavior parentPuzzle;

    [SerializeField]
    bool isOn = true;
    [SerializeField]
    bool shouldBeOn = false;

    private float intensity = 1f;

	// Use this for initialization
	void Start () {
        thisFire = GetComponentInChildren<ParticleSystem>();
        torch = GetComponentInChildren<Light>();
        fireSound = GetComponent<AudioSource>();     
        parentPuzzle = transform.parent.gameObject.GetComponentInChildren<puzzle_behavior>();
        setFire();
    }

    //sets the particles to start/stop based on isOn
    void setFire() {
        if (isOn){
            thisFire.Play();
            torch.intensity = intensity;
            fireSound.Play();
        }
        else{
            thisFire.Stop();
            torch.intensity = .5f;
            fireSound.Stop();
            
        }
    }

    void OnTriggerEnter(Collider other){
        isOn = !isOn;
        setFire();
        connectTorch.isOn = !connectTorch.isOn;
        connectTorch.setFire();
        if (connectTorch02)
        {
            connectTorch02.isOn = !connectTorch02.isOn;
            connectTorch02.setFire();
        }
        parentPuzzle.checkPuzzleSolved();
    }

    public bool getIsOn() { return isOn; }
    public bool getShouldBeOn() { return shouldBeOn; }
}
