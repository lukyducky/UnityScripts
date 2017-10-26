using UnityEngine;
using System.Collections;

public class enemy_territory : MonoBehaviour {
    public BoxCollider territory;
    GameObject player;
    bool playerInTerritory;

    public GameObject enemy;
    basic_enemy basicEnemy;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        basicEnemy = enemy.GetComponent<basic_enemy>();
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory == true)
        {
            basicEnemy.MoveToPlayer();
        }

        if (playerInTerritory == false)
        {
            basicEnemy.Rest();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = false;
        }
    }

    
}
