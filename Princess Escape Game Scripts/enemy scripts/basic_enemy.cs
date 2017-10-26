using UnityEngine;
using System.Collections;

public class basic_enemy : MonoBehaviour {

    public Transform target;
    public float speed = 3f;
    public float attack1Range = 1f;
    //public int attack1Damage = 1;
    public float timeBetweenAttacks;
    enemy_waypoint waypoint;
    public int health = 10;
    
    // Use this for initialization
    void Start()
    {
        GetComponent<enemy_waypoint>().enabled = false;
        Rest();
    }

    public void MoveToPlayer()
    {
        GetComponent<enemy_waypoint>().enabled = false;

        //rotate to look at player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        //move towards player
        if (Vector3.Distance(transform.position, target.position) > attack1Range)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    public void Rest()
    {
        GetComponent<enemy_waypoint>().enabled = true;
    }


    void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
