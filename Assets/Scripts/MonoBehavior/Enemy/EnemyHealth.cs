using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ********************/
    public GameObject pfEnemyHitExplosion;
    public GameObject pfEnemyDeathExplosion;
    public float MAX_HEALTH;
    public float DAMAGE;

    /******************** PRIVATE VARIABLES ********************/
    private float CURR_HEALTH;

    
    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start()
    {
        CURR_HEALTH = MAX_HEALTH;
    }

    /******************** PRIVATE FUNCTIONS ***************/
    private void die()
    {
        Instantiate(pfEnemyDeathExplosion, gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
        Destroy(gameObject);
    }

    void playHitAnimation()
    {
        Instantiate(pfEnemyHitExplosion, gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
    }

    /******************** PUBLIC FUNCTIONS ***************/
    public void takeDamage(float DMG) 
    {
        CURR_HEALTH -= DMG;

        if(CURR_HEALTH <= 0.0f)
        {
            die();
        } 
        else 
        {
            playHitAnimation();
        }
        
    }

    public float getDamage()
    {
        return DAMAGE;
    } 
}
