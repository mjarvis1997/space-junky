using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/

    /******************** PUBLIC VARIABLES ***************/
    private Animator myAnimator;
    private Rigidbody2D playerRigidbody2D;
    //private Transform playerTransform;
    private Vector3 moveDir;
    private float MOVE_SPEED = 7.5f;


    /******************** UNITY FUNCTIONS ***************/
    // Start is called before the first frame update
    void Start()
    {
        // initialize reference to components
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        //playerTransform = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    // handle physics here
    private void FixedUpdate()
    {
        // move the player
        playerRigidbody2D.velocity = moveDir * MOVE_SPEED;
        //playerTransform.position += moveDir * MOVE_SPEED;
    }

    /******************** PRIVATE FUNCTIONS ***************/
    private void HandleMovement () 
    {
        // initalize vars to store input
        float moveX, moveY;
        moveX = moveY = 0f;

        // handle user input
        if(Input.GetKeyDown(KeyCode.W)) {
            myAnimator.SetBool("isUpPressed", true);
        }
        if(Input.GetKeyDown(KeyCode.S)) {
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            myAnimator.SetBool("isRightPressed", true);
        }
        if(Input.GetKeyDown(KeyCode.A)) {
            myAnimator.SetBool("isLeftPressed", true);

        }

        if(Input.GetKeyUp(KeyCode.W)) {
            myAnimator.SetBool("isUpPressed", false);
        }
        if(Input.GetKeyUp(KeyCode.S)) {
        }
        if(Input.GetKeyUp(KeyCode.D)) {
            myAnimator.SetBool("isRightPressed", false);
        }
        if(Input.GetKeyUp(KeyCode.A)) {
            myAnimator.SetBool("isLeftPressed", false);

        }



        if(Input.GetKey(KeyCode.W)) {
            moveY = +1f;
        }
        if(Input.GetKey(KeyCode.S)) {
            moveY = -1f;
        }
        if(Input.GetKey(KeyCode.D)) {
            moveX = +1f;
        }
        if(Input.GetKey(KeyCode.A)) {
            moveX = -1f;
        }

        // store result of user input in private vector
        moveDir = new Vector3(moveX, moveY).normalized;
    }
}
