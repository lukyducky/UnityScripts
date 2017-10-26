using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {
    public float speed = 6f;

    Vector3 movement; //store direction of player movement
    //need a ref to animation component if any
    Rigidbody playerRigidbody; //ref to player rigidbody component
    int floormask; //layermask so ray can cast on just game object
    float camRayLength = 1000f; //length of ray from cam into scene
    hero_inventory inventory;
    CharacterController control;
    float hitRange = 1f;
    

    void Awake()
    {
        floormask = LayerMask.GetMask("Floor");

        //setting up references
        //add animator reference here
        playerRigidbody = GetComponent<Rigidbody>();
        control = GetComponent<CharacterController>();
        inventory = GetComponent<hero_inventory>();
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            attack();
        }
    }

	
    void FixedUpdate()
    {
        //storing input axis
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //move player
        movePlayer(h, v);
        Turning(); //turn player to face mouse curser
        
    }
    void movePlayer (float h, float v)
    {
        //set movement vector paset on axis input!
        movement.Set(h, 0f, v); //y is zero: stays on this plane

        movement = movement.normalized * speed * Time.deltaTime; //normalizing diagonals for consistency

        playerRigidbody.MovePosition(transform.position + movement);
        control.Move(movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit; //stores info about what was hit by ray

        //perform raycast; if it hits something on the floor...
        if (Physics.Raycast(camRay, out floorHit, floormask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position; //vector from player 

            playerToMouse.y = 0f; //keeps vector on floor plane
           // Debug.Log("PlayerToMouse: " + playerToMouse);

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //Debug.Log("newRotation " + newRotation);
            //set player rotation to new rotation

            playerRigidbody.MoveRotation(newRotation);
            //transform.rotation = newRotation;
           // Debug.Log("PlayerRigidBody" + playerRigidbody);
        }
        else
            Debug.Log("ray didn't hit!");
    }


    void attack()
    {
        if (inventory.hasItem(hero_inventory.pickUpItems.Weapon))
        {
            RaycastHit hit;
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 origin = transform.position;
            if(Physics.Raycast(origin, forward, out hit, hitRange))
            {
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.SendMessage("TakeDamage", 5);
                }
                if(hit.transform.gameObject.tag == "destructible")
                {
                    hit.transform.gameObject.SendMessage("damageThis", 1);
                }
            }
        }
        
    }
}
