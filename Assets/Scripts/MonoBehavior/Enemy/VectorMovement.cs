using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMovement : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ********************/

    /******************** PRIVATE VARIABLES ***************/
    private Rigidbody2D rb;
    private Transform ts;

    private Vector3 checkpointPosition;
    private float distanceTraveled;
    private bool isDoneChangingVectors = false;

    private List<VectorPath> vectorInfo;
    private VectorPath curr;
    private int currentVector = 0;


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
    public void setPaths(List<VectorPath> vectorInfo)
    {
        this.vectorInfo = vectorInfo;
        curr = vectorInfo[0];
    }


    /******************** PRIVATE FUNCTIONS ***************/
    void handleMovement() 
    {
        // if we have finished traveling the current vector in the list
        if(!isDoneChangingVectors && distanceTraveled >= vectorInfo[currentVector].move_distance)
        {
            // increment to next vector
            ++currentVector;

            // update position of checkpoint and vector reference
            checkpointPosition = ts.position;
            curr = vectorInfo[currentVector];

            // if this is the last vector in the list
            if(currentVector == vectorInfo.Count - 1)
            {
                isDoneChangingVectors = true;
            }
        }

        // move based on current path in list
        rb.MovePosition(ts.position + (curr.move_dir * curr.move_speed * Time.deltaTime));
    }
}


