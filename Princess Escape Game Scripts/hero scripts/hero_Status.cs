using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class hero_Status : MonoBehaviour {

    public float maxHealth = 10.0f;
    float health;

    float energy;
    public float maxEnergy = 10.0f;

    //float boostUsage = 5.0f;

    hero_controller pController;
    hero_inventory inventory;

    CharacterController controller;

    MeshRenderer mRend;
    CheckPoint activeCheck;

    public int lives = 3;


    // Use this for initialization
    void Start () {
        pController = GetComponent<hero_controller>();
        controller = GetComponent<CharacterController>();
        mRend = GetComponent<MeshRenderer>();
        inventory = GetComponent<hero_inventory>();
        health = maxHealth;
        energy = maxHealth;
        activeCheck = GameObject.Find("check_point").GetComponent<CheckPoint>();
        activeCheck = activeCheck.getActive();
    }

    // Update is called once per frame
    void Update () {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public float getHealth() { return health; }

    public void applyDamage(float damage)
    {
        health -= damage;
    }

    public void addHealth(float inHealth)
    {
        health += inHealth;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        //needs to print to screen eventually
    }

    void Die()
    {
        HideCharacter();
        Debug.Log(activeCheck);
        if (!activeCheck.isActive)
        {
            Debug.Log("let's get active");
            activeCheck = activeCheck.getActive();
        }
        gameObject.transform.position = activeCheck.transform.position;
        ShowCharacter();
        health = maxHealth;
        lives--;
        if (lives <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }


    void HideCharacter()
    {
        mRend.enabled = false;
        pController.isControllable = false;
    }

    void ShowCharacter()
    {
        mRend.enabled = true;
        pController.isControllable = true;
    }

    float timeDelay = 0f;
    float delayAmount = 2.0f;

    void OnGUI()
    {
        GUI.Label(new Rect (10, 10, 150, 30), "Real time is =" + Time.realtimeSinceStartup.ToString("f2"));
        GUI.Label(new Rect (20, 20, 150, 30), "Health: " + health.ToString() + "/" + maxHealth.ToString());
        
    }


   
}
