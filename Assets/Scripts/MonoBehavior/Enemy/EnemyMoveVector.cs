using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveVector : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ********************/
    private List<VectorMovePath> paths;

    /******************** PRIVATE VARIABLES ***************/
    private Rigidbody2D rb;
    private Transform ts;

    private int currentVector = 0;
    private Vector3 checkpointPosition;
    private float distanceTraveled;
    private VectorMovePath curr;
    private bool isDoneChangingVectors = false;


    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ts = GetComponent<Transform>();
        checkpointPosition = ts.position;
    }

    void Update()
    {
        // update distance travelled
        distanceTraveled = Vector3.Distance(checkpointPosition, ts.position);
    }

    void FixedUpdate()
    {
        handleMovement();
    }

    /******************** PUBLIC FUNCTIONS ***************/
    public void setPaths(List<VectorMovePath> paths)
    {
        this.paths = paths;
        curr = paths[0];
    }


    /******************** PRIVATE FUNCTIONS ***************/
    void handleMovement() 
    {
        // if we have finished traveling the current vector in the list
        if(!isDoneChangingVectors && distanceTraveled >= paths[currentVector].MOVE_DISTANCE)
        {
            // increment to next vector
            ++currentVector;

            // update position of checkpoint and vector reference
            checkpointPosition = ts.position;
            curr = paths[currentVector];

            // if this is the last vector in the list
            if(currentVector == paths.Count - 1)
            {
                isDoneChangingVectors = true;
            }
        }

        // move based on current path in list
        rb.MovePosition(ts.position + (curr.MOVE_DIR * curr.MOVE_SPEED * Time.deltaTime));
    }
}


