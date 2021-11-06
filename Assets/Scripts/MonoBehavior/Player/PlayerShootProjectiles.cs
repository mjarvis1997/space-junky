using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectiles : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ********************/
    public int projectileCode;
    public Transform PREFAB_ROCKET;
    public Transform PREFAB_ENERGYBALL;

    /******************** PRIVATE VARIABLES ********************/
    private int PROJECTILE_PF_ROCKET = 0;
    private int PROJECTILE_PF_ENERGY_BALL = 1;

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start()
    {
        Player player = GetComponent<Player>();

        // subscribe to player event handler
        player.OnSpacePressed += Private_OnSpacePressed;
    }

    /******************** PRIVATE EVENT HANDLERS ********************/

    // shoot projectiles when space bar is pressed
    private void Private_OnSpacePressed(object sender, Player.OnSpacePressedEventArgs e) 
    {
        Utilities.logEvent("Space", "PlayerShootProjectiles");
        shootProjectiles(e.projectileStartLocation);
    }

    private void shootProjectiles(Vector3 pos)
    {
        ProjectileSettings settings;
        Transform ts;
        Transform prefab;

        // configure projectile settings based on the one we are using
        switch(projectileCode) 
        {
            case 0:
                settings = GlobarVars.PROJECTILE_ROCKET;
                prefab = PREFAB_ROCKET;
                break;

            case 1:
                settings = GlobarVars.PROJECTILE_ENERGYBALL;
                prefab = PREFAB_ENERGYBALL;
                break;

            default:
                settings = GlobarVars.PROJECTILE_ROCKET;
                prefab = PREFAB_ROCKET;
                break;
        }

        for(int shot = 0; shot < settings.SHOTS.Length; ++shot)
        {
            ts = Instantiate(prefab, pos, Quaternion.Euler(new Vector3(0,0,0)));
            ts.GetComponent<Projectile>().Configure(settings.MOVE_SPEED, settings.BULLET_DAMAGE, settings.MAX_NUM_OF_ENEMIES, settings.SHOTS[shot]);
        }
    }

}
