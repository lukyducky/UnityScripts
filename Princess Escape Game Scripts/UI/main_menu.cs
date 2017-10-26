using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour {

    public Canvas helpMenu;
    public Button startText;
    public Button helpText;

	// Use this for initialization
	void Start () {
        helpMenu = helpMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        helpText = helpText.GetComponent<Button>();
        helpMenu.enabled = false;
	}

    public void HelpPress()
    {
        helpMenu.enabled = true;
        startText.enabled = false;
        helpText.enabled = false;
    }

    public void BackPress() //back button on help menu
    {
        helpMenu.enabled = false;
        startText.enabled = true;
        helpText.enabled = true;
    }
	
    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    

	// Update is called once per frame
	void Update () {
	
	}
}
