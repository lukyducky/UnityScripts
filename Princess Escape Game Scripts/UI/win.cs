using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour {

    public int sceneIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
