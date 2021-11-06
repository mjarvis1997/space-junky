using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float DISTANCE_BETWEEN_EACH_SPAWN_X;
    public float DISTANCE_BETWEEN_EACH_SPAWN_Y;
    public Vector3 START_POSITION = new Vector3(10,4,0);
    public Transform pfPlasticRings;

    void Start()
    {
        spawnEnemy(pfPlasticRings, START_POSITION, Quaternion.Euler(new Vector3(0, 0, 90)), 0);
    }

    private void spawnEnemy(Transform pf, Vector3 pos, Quaternion orientation, int formation) 
    {
        switch (formation)
        {
            case 1:
                Debug.Log("hello");
                break;

            default:
                for(int i = 0; i < 5; ++i) 
                {
                    Instantiate(pf, pos, orientation);
                    pos.x += DISTANCE_BETWEEN_EACH_SPAWN_X;
                    pos.y += DISTANCE_BETWEEN_EACH_SPAWN_Y;
                }
                break;
        }
    }

}
