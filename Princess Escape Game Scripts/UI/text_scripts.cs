using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class text_scripts : MonoBehaviour {

    Text gui;

    void Start()
    {
        gui = GetComponent<Text>(); //->gets the right thing.
        gui.enabled = false;
    }

	public void textHints(string s) //shows and unshows.
    {
        gui.enabled = true;
        gui.text = s; //->changes the thing
        Debug.Log(gui.text);
        wait(3.0f);
        gui.enabled = false;
    }

    public IEnumerator wait(float inF)
    {
        yield return new WaitForSeconds(inF);
    }
}
