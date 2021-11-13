using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ********************/
    public GameObject pfPlasticRings;
    public GameObject pfPirateShip;

    /******************** PRIVATE VARIABLES ********************/
    private int enemiesAlive = 0;
    private List<GameObject> enemies;
    private bool waveIsOver = false;
    private int waveCount = 0;

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start()
    {
        // spawn first wave
        enemies = spawnEnemies(pfPlasticRings, GlobalVars.PATH_ZIGZAG_DOWN, GlobalVars.SPAWN_BASIC_LEFT, 5);
    }

    void Update()
    {
        // reset enemy count
        enemiesAlive = 0;

        // count how many enemies are alive
        foreach (GameObject enemy in enemies)
        {
            if(enemy != null)
            {
                enemiesAlive += 1;
            }
        }

        // if all enemies are dead
        if(enemiesAlive == 0)
        {
            waveIsOver = true;
            Debug.Log("WAVE HAS FINISHED!!!");
        }

        if(waveIsOver)
        {
            // TODO: different prefabs, patterns
            // localize enemy possibilites to a given region or group of waves
            if(waveCount % 5 == 0)
            {
                enemies = spawnEnemies(pfPirateShip, GlobalVars.PATH_ZIGZAG_DOWN, GlobalVars.SPAWN_BASIC_LEFT, 1);
            }
            else {
                enemies = spawnEnemies(pfPlasticRings, GlobalVars.PATH_ZIGZAG_DOWN, GlobalVars.SPAWN_BASIC_LEFT, 5);
            }
            waveIsOver = false;
        }
    }

    /******************** PRIVATE FUNCTIONS ***************/
    // spawns enemies and configures their movement paths
    private List<GameObject> spawnEnemies(GameObject pf, List<VectorPath> paths, SpawnConfig config, int count) 
    {
        // used to store references to each Gameobject we instantiate
        List<GameObject> enemies = new List<GameObject>();
        GameObject go;

        // for each enemy
        for(int i = 0; i < count; ++i)
        {
            // instantiate at proper position
            go = Instantiate(pf, config.start_pos + (config.pos_offset * i), config.orientation); 

            // configure move paths
            go.GetComponent<VectorMovement>().setPaths(paths);

            // store reference to enemy in list
            enemies.Add(go);
            enemiesAlive += 1;
        }
        ++waveCount;
        return enemies;
    }
}
