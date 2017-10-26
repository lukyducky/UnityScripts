using UnityEngine;
using System.Collections;

public class hero_controller : MonoBehaviour {
    //initializing chara movement variables
    float walkSpeed = 2.0f;
    //float runSpeed = 2.0f;
    //float gravity = 20.0f;
    public float rotateSpeed = 2.0f;
    //float jumpSpeed = 8.0f;

    private Vector3 moveDir = Vector3.zero;
    private Vector3 rotateDir = Vector3.zero;

    //private bool isGrounded = true;
    private float moveHorz = 0.0f;

   public bool isControllable = true;

    //store ref to character controller
    CharacterController control;
    

	// Use this for initialization
	void Start () {
       control = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(!isControllable)
        {
            Input.ResetInputAxes();
        }
        else
        {
            
                //sets the forward/backward vector & moves
                moveDir = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= walkSpeed;

                //sets the horizontal vector 
                moveHorz = Input.GetAxis("Horizontal");
                if (moveHorz > 0f)
                {
                    rotateDir = new Vector3(0f, 1f, 0f);
                }
                else if (moveHorz < 0f)
                {
                    rotateDir = new Vector3(0f, -1f, 0f);
                }
                else
                {
                    rotateDir = new Vector3(0f, 0f, 0f);
                }

                //move the character
                control.transform.Rotate(rotateDir * Time.deltaTime, rotateSpeed);
                control.Move(moveDir * Time.deltaTime);
            
        }



	}//end fixed update
}//end class
