using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzle_behavior : MonoBehaviour
{
    /*
     attached to door.  checks if it's open or not and it does a thing.
    */

    puzzle_torch[] siblings;
    bool shouldOpen = true;
    text_Trigger tScript;
    Light spotLight;
    AudioSource sound;
 
    void Start()
    {
        siblings = transform.parent.gameObject.GetComponentsInChildren<puzzle_torch>();
        tScript = gameObject.GetComponent<text_Trigger>();
        sound = GetComponent<AudioSource>();
        Debug.Log(sound);
    }

    public void checkPuzzleSolved()
    {
        //check each child in thing
        for (int i = 0; i < siblings.Length; i++) //for each of the children
        {
            if (siblings[i].getIsOn() != siblings[i].getShouldBeOn()) //check if the torches are correctly lit
            {
                shouldOpen = false;
                break;
            }
            else { shouldOpen = true; }
        }
        if (shouldOpen)
        {
            StartCoroutine(wait(1.5f));
            gameObject.SetActive(false);
            disableCollidersInChildren();
            sound.Play();

        }
    }


    void OnTriggerEnter(Collider other)
    {
        tScript.hintPopUp();
    }

    void disableCollidersInChildren()
    {
            for (int i = 0; i < siblings.Length; i++) //for each of the children
            {
                siblings[i].GetComponent<Collider>().isTrigger = false;
            }
        }

    IEnumerator wait(float t)
    {
        yield return new WaitForSeconds(t);

    }

}

