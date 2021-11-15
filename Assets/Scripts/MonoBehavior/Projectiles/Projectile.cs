using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/
    
    /******************** PRIVATE VARIABLES ***************/
    private float MOVE_SPEED;
    private float BULLET_DAMAGE;
    private int MAX_NUM_OF_ENEMIES;
    private Vector3 SHOOT_DIR;
    private Rigidbody2D rb;
    private Transform ts;
    private Camera cam;
    private float cameraHeight;
    private float cameraWidth;
    // how far a projectile can travel off camera before being deleted
    private float cameraOffset = 30;

    private int numOfEnemyCollisions = 0;
    private List<string> namesOfEnemiesHit = new List<string>();

    /******************** PUBLIC FUNCTIONS ***************/
    public void Configure(float MOVE_SPEED, float BULLET_DAMAGE, int MAX_NUM_OF_ENEMIES, Vector3 SHOOT_DIR) 
    {
        this.MOVE_SPEED = MOVE_SPEED;
        this.BULLET_DAMAGE = BULLET_DAMAGE;
        this.MAX_NUM_OF_ENEMIES = MAX_NUM_OF_ENEMIES;
        this.SHOOT_DIR = SHOOT_DIR;
    }

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ts = GetComponent<Transform>();

        // store camera dimensions
        // cameraOffset determines how far a projectile can travel off camera before being deleted
        cam = Camera.main;
        cameraHeight = (2f * cam.orthographicSize) + cameraOffset;
        cameraWidth = (cameraHeight * cam.aspect) + cameraOffset;
    }

    void Update()
    {
        // if projectile goes off screen
        if(Math.Abs(ts.position.x) > cameraWidth/2 || Math.Abs(ts.position.y) > cameraHeight/2 )
        {
            Debug.Log("projectile is off screen!");
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // move projectile
        rb.MovePosition(ts.position + SHOOT_DIR * MOVE_SPEED * Time.deltaTime);
    }

    /******************** COLLISION HANDLERS ********************/
    private void OnTriggerEnter2D(Collider2D col) 
    {
        // if collision is with an enemy
         if(col.gameObject.layer == GlobalVars.LAYER_ENEMIES)
         {
             HandleEnemyCollision(col.gameObject);
         }
    }
    
    public void HandleEnemyCollision(GameObject go)
    {
        GameObject parentGo = Utilities.findNonGenericParent(go);
        string parentName = parentGo.name;

        // log collision
        Utilities.logCollision("Bullet", parentName);

        // conditions for valid collision
        bool isBelowMaxNumOfCollisions = numOfEnemyCollisions < MAX_NUM_OF_ENEMIES;
        bool isRepeatCollision = false;

        // check if bullet has already collided with this enemy
        foreach(string name in namesOfEnemiesHit) 
        {
            if(name == parentName)
            {
                isRepeatCollision = true;
            }
        }

        // decide if the collision is valid
        if(isBelowMaxNumOfCollisions && !isRepeatCollision) 
        {
            // tell the enemy to take damage
            parentGo.GetComponent<EnemyHealth>().takeDamage(BULLET_DAMAGE);
            Debug.Log("projectile stats - isBelowMaxNumOfCollisions: " + isBelowMaxNumOfCollisions + " | isRepeatCollision: " + isRepeatCollision);

            // log damage
            Utilities.logDamage(parentName, gameObject.name, BULLET_DAMAGE);

            // store name of object we collided with and increment counter
            namesOfEnemiesHit.Add(parentName);
            numOfEnemyCollisions++;

        }
    }
}
