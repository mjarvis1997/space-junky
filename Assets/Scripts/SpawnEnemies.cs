using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ********************/
    public GameObject pfPlasticRings;

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start()
    {
        spawnEnemies(pfPlasticRings, GlobalVars.PATH_ZIGZAG_DOWN, GlobalVars.SPAWN_BASIC_LEFT);
    }

    /******************** PRIVATE FUNCTIONS ***************/

    // spawns enemies and configures their movement paths
    private void spawnEnemies(GameObject pf, List<VectorPath> paths, SpawnConfig config) 
    {
        // used to store temporary references to each Gameobject we instantiate
        GameObject go;

        // for each enemy
        for(int i = 0; i < config.count; ++i)
        {
            // instantiate at proper position
            go = Instantiate(pf, config.start_pos + (config.pos_offset * i), config.orientation); 

            // configure move paths
            go.GetComponent<VectorMovement>().setPaths(paths);
        }
    }

}
