using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/

    /******************** PRIVATE VARIABLES ***************/
    Animator myAnimator;
    Rigidbody2D playerRigidbody2D;
    Player player;
    //private Transform playerTransform;
    Vector3 moveDir;
    float MOVE_SPEED = 7.5f;

    // button press states
    bool isWDown, isWUp, isWPressed;
    bool isADown, isAUp, isAPressed;
    bool isSDown, isSUp, isSPressed;
    bool isDDown, isDUp, isDPressed;


    /******************** UNITY FUNCTIONS ***************/
    // Start is called before the first frame update
    void Start()
    {
        // initialize reference to components
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        //playerTransform = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.checkIfPlayerIsAlive())
        {
            HandleMovement();        
        } 
        else 
        {
            // stop movement
            moveDir = new Vector3(0,0,0);
        }
    }

    // handle physics here
    private void FixedUpdate()
    {
        // move the player
        playerRigidbody2D.velocity = moveDir * MOVE_SPEED;
    }
    /******************** PRIVATE FUNCTIONS ***************/
    private void checkStateOfUserInput()
    {
        // stores state of key presses in boolean vars
        isWDown = Input.GetKeyDown(KeyCode.W);
        isWUp = Input.GetKeyUp(KeyCode.W);
        isWPressed = Input.GetKey(KeyCode.W);

        isADown = Input.GetKeyDown(KeyCode.A);
        isAUp = Input.GetKeyUp(KeyCode.A);
        isAPressed = Input.GetKey(KeyCode.A);

        isSDown = Input.GetKeyDown(KeyCode.S);
        isSUp = Input.GetKeyUp(KeyCode.S);
        isSPressed = Input.GetKey(KeyCode.S);
        
        isDDown = Input.GetKeyDown(KeyCode.D);
        isDUp = Input.GetKeyUp(KeyCode.D);
        isDPressed = Input.GetKey(KeyCode.D);
    }

    private void HandleMovement () 
    {
        // initalize vars to store input
        float moveX, moveY;
        moveX = moveY = 0f;

        checkStateOfUserInput();
        // animations for movement based on user input
        if(isWDown) { myAnimator.SetBool("isUpPressed", true); }
        if(isSDown) { }
        if(isDDown) { myAnimator.SetBool("isRightPressed", true); }
        if(isADown) { myAnimator.SetBool("isLeftPressed", true);  }

        if(isWUp) { myAnimator.SetBool("isUpPressed", false); }
        if(isSUp) { }
        if(isDUp) { myAnimator.SetBool("isRightPressed", false); }
        if(isAUp) { myAnimator.SetBool("isLeftPressed", false);  }

        // vector math for movement based on user input
        if(isWPressed) { moveY = +1f; }
        if(isSPressed) { moveY = -1f; }
        if(isDPressed) { moveX = +1f; }
        if(isAPressed) { moveX = -1f; }

        if(player.checkIfPlayerIsAlive())
        {
            // store result of user input in private vector
            moveDir = new Vector3(moveX, moveY).normalized;
        }
    }
}
