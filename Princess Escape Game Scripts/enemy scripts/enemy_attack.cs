using UnityEngine;
using System.Collections;

public class enemy_attack : MonoBehaviour {
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    //Animator anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    hero_Status playerHealth;                  // Reference to the player's health.
    basic_enemy enemy;
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<hero_Status>();
        enemy = GetComponent<basic_enemy>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemy.health > 0)
        {
            // ... attack.
            Attack();
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.getHealth() > 0)
        {
            // ... damage the player.
            playerHealth.applyDamage(3.0f);
        }
    }
}
