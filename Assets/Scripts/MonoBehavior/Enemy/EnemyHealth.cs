using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ********************/
    public float MAX_HEALTH;
    public float DAMAGE;
    public float MOVE_SPEED;
    public Vector3 MOVE_DIR;

    /******************** PRIVATE VARIABLES ********************/
    private float CURR_HEALTH;

    
    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start()
    {
        CURR_HEALTH = MAX_HEALTH;
    }

    void Update()
    {
        handleHealth();
        handleMovement();
    }

    /******************** PRIVATE FUNCTIONS ***************/
    private void die()
    {
        Destroy(gameObject);
    }

    private void handleHealth() 
    {
        if (CURR_HEALTH <= 0.0f) 
        {
            die();
        }
    }

    void handleMovement() {

        // move enemy
        //transform.position += MOVE_DIR * MOVE_SPEED * Time.deltaTime;
    }

    /******************** PUBLIC FUNCTIONS ***************/
    public void takeDamage(float DMG) {
        CURR_HEALTH -= DMG;
    }

    public float getDamage()
    {
        return DAMAGE;
    } 
}
