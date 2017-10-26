using UnityEngine;
using System.Collections;

public class light_torch : MonoBehaviour
{

    Light torch;
    ParticleSystem thisFire;
    bool isOn = true;
    //hero_inventory inventory;
    float intense = 1f;
    AudioSource sound;

    // Use this for initialization
    void Start()
    {
        torch = GetComponentInChildren<Light>();
        thisFire = GetComponentInChildren<ParticleSystem>();
        sound = GetComponent<AudioSource>();
        setFire();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        setFire();
    }


    void setFire()
    {
        if (!isOn)
        {
            torch.intensity = intense;
            thisFire.Play();
            // isOn = !isOn;
            sound.Play();
        }
        else
        {
            thisFire.Stop();
            torch.intensity = .35f;
            isOn = !isOn;
            sound.Pause();

        }
    }
}
