using System;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    // int mapping for layers
    public static int LAYER_DEFAULT = 0;
    public static int LAYER_TRANSPARENT_FX = 1;
    public static int LAYER_IGNORE_RAYCAST = 2;
    public static int LAYER_WATER = 4;
    public static int LAYER_UI = 5;
    public static int LAYER_PLAYER_PROJECTILES = 6;
    public static int LAYER_PLAYER_SHIP = 7;
    public static int LAYER_ENEMIES = 8;

    // projectile settings

    // rocket
    public static float PROJECTILE_ROCKET_MOVE_SPEED = 15;
    public static float PROJECTILE_ROCKET_BULLET_DAMAGE = 50;
    public static int PROJECTILE_ROCKET_MAX_NUM_OF_ENEMIES = 2;
    public static Vector3[] PROJECTILE_ROCKET_VECTORS = new Vector3[] {
        Vector3.up,
    }; 

    // energy ball
    public static float PROJECTILE_ENERGYBALL_MOVE_SPEED = 10;
    public static float PROJECTILE_ENERGYBALL_BULLET_DAMAGE = 34;
    public static int PROJECTILE_ENERGYBALL_MAX_NUM_OF_ENEMIES = 1;
    public static Vector3[] PROJECTILE_ENERGYBALL_VECTORS = new Vector3[] {
        Vector3.up,
        Vector3.up + Vector3.left,
        Vector3.up + Vector3.right,
    }; 

    
    // objects to store each projectiles properties
    public static ProjectileSettings PROJECTILE_ROCKET = new ProjectileSettings(
        PROJECTILE_ROCKET_VECTORS,
        PROJECTILE_ROCKET_MOVE_SPEED,
        PROJECTILE_ROCKET_BULLET_DAMAGE,
        PROJECTILE_ROCKET_MAX_NUM_OF_ENEMIES
    );

    public static ProjectileSettings PROJECTILE_ENERGYBALL = new ProjectileSettings(
        PROJECTILE_ENERGYBALL_VECTORS,
        PROJECTILE_ENERGYBALL_MOVE_SPEED,
        PROJECTILE_ENERGYBALL_BULLET_DAMAGE,
        PROJECTILE_ENERGYBALL_MAX_NUM_OF_ENEMIES
    );

    // frequently used references
    static Quaternion defaultOrientation = Quaternion.Euler(new Vector3(0, 0, 0));

    // movement paths

    // basic zig zag pattern that travels down and to the right
    public static List<VectorPath> PATH_ZIGZAG_DOWN = new List<VectorPath>()
    {
        new VectorPath(2, 6, Vector3.down + Vector3.right),
        new VectorPath(2, 6, (Vector3.up * 0.5f) + Vector3.right),
        new VectorPath(2, 4, Vector3.down + Vector3.right),
        new VectorPath(2, 4, (Vector3.up * 0.5f) + Vector3.right),
        new VectorPath(2, 4, Vector3.down + Vector3.right)
    };

    public static List<VectorPath> PATH_SQUARE_WAVE_RIGHT = new List<VectorPath>()
    {
        new VectorPath(2, 5, Vector3.right),
        new VectorPath(2, 5, Vector3.down),
        new VectorPath(2, 5, Vector3.right),
        new VectorPath(2, 5, Vector3.up),
        new VectorPath(2, 5, Vector3.right),
        new VectorPath(2, 5, Vector3.down)
    };

    public static List<VectorPath> PATH_SQUARE_WAVE_LEFT = new List<VectorPath>()
    {
        new VectorPath(2, 5, Vector3.left),
        new VectorPath(2, 5, Vector3.down),
        new VectorPath(2, 5, Vector3.left),
        new VectorPath(2, 5, Vector3.up),
        new VectorPath(2, 5, Vector3.left),
        new VectorPath(2, 5, Vector3.down)
    };

    public static List<VectorPath> PATH_RR = new List<VectorPath>()
    {
        new VectorPath(2, 8, Vector3.up),
        new VectorPath(2, 4, Vector3.right),
        new VectorPath(2, 4, Vector3.down),
        new VectorPath(2, 4, Vector3.left),
        new VectorPath(2, 6, Vector3.down + Vector3.right),
        new VectorPath(2, 8, Vector3.up),
        new VectorPath(2, 4, Vector3.right),
        new VectorPath(2, 4, Vector3.down),
        new VectorPath(2, 4, Vector3.left),
        new VectorPath(2, 6, Vector3.down + Vector3.right)
    };

    public static List<VectorPath> PATH_TRIANGLE = new List<VectorPath>()
    {
        new VectorPath(2, 8, Vector3.up + Vector3.right),
        new VectorPath(2, 6, Vector3.left),
        new VectorPath(2, 10, Vector3.down + Vector3.right)
    };

    public static List<VectorPath> PATH_TRIANGLE_REPEAT = new List<VectorPath>()
    {
        new VectorPath(2.5f, 6f, Vector3.up + Vector3.right),
        new VectorPath(2.5f, 4f, Vector3.left),
        new VectorPath(2.5f, 3f, Vector3.down + Vector3.right),
        new VectorPath(2.5f, 6f, Vector3.up + Vector3.right),
        new VectorPath(2.5f, 4f, Vector3.left),
        new VectorPath(2.5f, 3f, Vector3.down + Vector3.right),
        new VectorPath(2.5f, 6f, Vector3.up + Vector3.right),
        new VectorPath(2.5f, 4f, Vector3.left),
        new VectorPath(2.5f, 3f, Vector3.down + Vector3.right)
    };

    public static SpawnConfig SPAWN_BASIC_LEFT = new SpawnConfig
    (
        new Vector3(-10, 7, 0), 
        Vector3.down + Vector3.left,
        defaultOrientation
    );

    public static SpawnConfig SPAWN_BASIC_RIGHT = new SpawnConfig
    (
        new Vector3(10, 7, 0), 
        Vector3.down + Vector3.right,
        defaultOrientation
    );
}
