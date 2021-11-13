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
    private Camera cam;
    private float cameraHeight;
    private float cameraWidth;
    // how far an enemy can travel off camera before being deleted
    private float cameraOffset = 30;

    private List<VectorPath> vectorInfo;
    private VectorPath curr;
    private Vector3 checkpointPosition;
    private float distanceTraveled;
    private bool hasReachedFinalVector = false;
    private int currentVector = 0;
    

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Awake()
    {
        // get necessary references
        rb = GetComponent<Rigidbody2D>();
        ts = GetComponent<Transform>();
        cam = Camera.main;
    }

    void Start()
    {
        // store camera dimensions
        cameraWidth = (cameraHeight * cam.aspect) + cameraOffset;
        cameraHeight = (2f * cam.orthographicSize) + cameraOffset;

        // store starting position as first checkpoint
        checkpointPosition = ts.position;
    }

    void Update()
    {
        // update distance travelled
        distanceTraveled = Vector3.Distance(checkpointPosition, ts.position);

        // if enemy goes out of bounds
        if(Math.Abs(ts.position.x) > cameraWidth/2 || Math.Abs(ts.position.y) > cameraHeight/2 )
        {
            Debug.Log("enemy is off screen!");
            Destroy(gameObject);
        }
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
        if(distanceTraveled >= vectorInfo[currentVector].move_distance)
        {
            if(hasReachedFinalVector)
            {
                //Destroy(gameObject);
            } 
            else {
                // increment to next vector
                ++currentVector;

                // update position of checkpoint and vector reference
                checkpointPosition = ts.position;
                curr = vectorInfo[currentVector];

                // if this is the last vector in the list
                if(currentVector == vectorInfo.Count - 1)
                {
                    hasReachedFinalVector = true;
                }
            }

        }

        // move based on current path in list
        rb.MovePosition(ts.position + (curr.move_dir * curr.move_speed * Time.deltaTime));
    }
}


