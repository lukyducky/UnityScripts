using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class text_Trigger : MonoBehaviour {

    public string inString;
    Text tScript;
    public int waitTime = 2;


    // Use this for initialization
    void Start () {
        //guiGO = GameObject.Find("Text_Hint");
        tScript = GameObject.Find("Text_Hint").GetComponent<Text>();
        
        tScript.enabled = false;
    }
    /*
    void OnTriggerEnter(Collider other){
        tScript.text = inString;
        tScript.enabled = true;
        Invoke("unShow", waitTime);
      // guiGO.GetComponent<text_scripts>().textHints(inString);
    }*/

    public void hintPopUp()
    {
        tScript.text = inString;
        tScript.enabled = true;
        Invoke("unShow", waitTime);
    }


    public void unShow()
    {
        tScript.enabled = false;
    }
}
