using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Player : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/
    public GameObject hitAnimation;
    public GameObject deathAnimation;

    /******************** PRIVATE VARIABLES ***************/
    private float CURR_HEALTH = 3;
    private float MAX_HEALTH = 3;
    private Vector3 TipOfShipPosition;
    private Vector3 tipOfShipPosition;
    private int frameCounter = 0;
    private int numOfIFrames = 300;
    private bool isPlayerInvincible = false;

    
    /******************** PUBLIC EVENTS ********************/
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;

    public class OnSpacePressedEventArgs : EventArgs {
        public Vector3 projectileStartLocation;
    }
    
    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start()
    {
        // attach function to event
        OnSpacePressed += Private_OnSpacePressed;
        
        // initialize tip of ship tipofship position
        tipOfShipPosition = GameObject.Find("TipOfShip").transform.position;
    }

    void Update()
    {
        ++frameCounter;

        // reset invincibility after iframes pass
        if(frameCounter >= numOfIFrames)
        {
            isPlayerInvincible = false;
        }

        HandleShooting();

        // update current tip of ship position
        tipOfShipPosition = GameObject.Find("TipOfShip").transform.position;
    }

    void HandleShooting() 
    {
        // when space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {

            // update location of tip of ship
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs {
                projectileStartLocation = tipOfShipPosition
            });
        }
    }

    /******************** PUBLIC FUNCTIONS ********************/
    public void takeDamage(float DMG) {
        Utilities.logEvent(DMG + " taken", "PlasticRings");
        CURR_HEALTH -= DMG;
    }

    /******************** PRIVATE EVENT HANDLERS ********************/
    // these are published in Start()

    // when space bar is pressed
    private void Private_OnSpacePressed(object sender, EventArgs e) 
    {
    }

    /******************** COLLISION HANDLERS ********************/
    /*
    private void OnTriggerEnter2D(Collider2D col) 
    {
        // find name of root GameObject and log collision
        string nameOfCollisionObject = Utilities.findNameOfNonGenericParent(col.gameObject);
        Utilities.logCollision("Player", nameOfCollisionObject);

        // retrieve root GameObject
        GameObject parentGo = Utilities.findNonGenericParent(col.gameObject);

        // if player collides with enemy
        if (col.gameObject.layer == GlobarVars.LAYER_ENEMIES);
        {
            // player takes damange
            takeDamage(parentGo.GetComponent<Enemy>().getDamage());

            if(CURR_HEALTH >= 0)
            {
                // play damage animation
            }
            
            else
            {
                // play death animation
            }
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D col) 
    {
        Debug.Log("player collided with something");

        // if collision is with an enemy
         if(col.gameObject.layer == GlobarVars.LAYER_ENEMIES)
         {
             HandleEnemyCollision(col.gameObject);
         }
    }

    public void HandleEnemyCollision(GameObject go)
    {
        GameObject parentGo = Utilities.findNonGenericParent(go);
        string parentName = parentGo.name;

        // log collision
        Utilities.logCollision("Player", parentName);

        // decide if the collision is valid
        if(!isPlayerInvincible) 
        {
            // start iframes
            isPlayerInvincible = true;
            frameCounter = 0;

            // check how much damage the enemy deals
            float ENEMY_DMG = parentGo.GetComponent<Enemy>().getDamage();

            // take damage
            //takeDamage(ENEMY_DMG);
            gameObject.GetComponent<Player>().takeDamage(ENEMY_DMG);

            // log damage
            Utilities.logDamage( gameObject.name, parentName, ENEMY_DMG);

            Instantiate(hitAnimation, gameObject.transform.position + (GlobarVars.VECTOR_UP), Quaternion.Euler(new Vector3(0,0,0)));
        }
    }

    
}
