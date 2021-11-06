using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSettings
{
    public Vector3[] SHOTS;
    public float MOVE_SPEED;
    public float BULLET_DAMAGE;
    public int MAX_NUM_OF_ENEMIES;

    public ProjectileSettings( Vector3[] shots, float moveSpeed, float bulletDamage, int maxNumOfEnemies) {
        this.SHOTS = shots;
        this.MOVE_SPEED = moveSpeed;
        this.BULLET_DAMAGE = bulletDamage;
        this.MAX_NUM_OF_ENEMIES = maxNumOfEnemies;
    }
}
