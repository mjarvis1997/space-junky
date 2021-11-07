using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float DISTANCE_BETWEEN_EACH_SPAWN_X;
    public float DISTANCE_BETWEEN_EACH_SPAWN_Y;
    public GameObject pfPlasticRings;

    void Start()
    {
        // should be moved to a new class to avoid adding manually
        
        // enemy group 1
        Quaternion defaultOrientation = Quaternion.Euler(new Vector3(0, 0, 90));
        Vector3 START_POSITION = new Vector3(10, 6, 0);
        Vector3 POS_OFFSET = (Vector3.down) + (Vector3.right);
        List<VectorMovePath> paths = new List<VectorMovePath>();
        paths.Add(new VectorMovePath(2, 6, Vector3.down + Vector3.left));
        paths.Add(new VectorMovePath(2, 6, (Vector3.up * 0.8f) + Vector3.left));
        paths.Add(new VectorMovePath(2, 6, Vector3.down + Vector3.left));
        paths.Add(new VectorMovePath(2, 6, (Vector3.up * 0.5f) + Vector3.left));
        paths.Add(new VectorMovePath(2, 6, Vector3.down + Vector3.left));

        newSpawnEnemy(pfPlasticRings, 5, START_POSITION, POS_OFFSET, paths, defaultOrientation);

        // enemy group 2
        START_POSITION = new Vector3(-10, 6, 0);
        POS_OFFSET = (Vector3.down) + (Vector3.right);
        paths = new List<VectorMovePath>();
        paths.Add(new VectorMovePath(2, 6, Vector3.down + Vector3.right));
        paths.Add(new VectorMovePath(2, 6, (Vector3.up * 0.8f) + Vector3.right));
        paths.Add(new VectorMovePath(2, 6, Vector3.down + Vector3.right));
        paths.Add(new VectorMovePath(2, 6, (Vector3.up * 0.5f) + Vector3.right));
        paths.Add(new VectorMovePath(2, 6, Vector3.down + Vector3.right));

        newSpawnEnemy(pfPlasticRings, 5, START_POSITION, POS_OFFSET, paths, defaultOrientation);
    }

    private void spawnEnemy(GameObject pf, Vector3 pos, Quaternion orientation, int formation) 
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

    private void newSpawnEnemy(
        GameObject pf, 
        int count,
        Vector3 pos,
        Vector3 posOffset,
        List<VectorMovePath> paths,
        Quaternion orientation
        ) 
    {
        // used to store temporary references to each Gameobject we instantiate
        GameObject go;

        // for each enemy
        for(int i = 0; i < count; ++i)
        {
            // instantiate at proper position
            go = Instantiate(pf, pos + (posOffset * i), orientation);

            // configure move paths
            go.GetComponent<EnemyMoveVector>().setPaths(paths);
        }
    }

}
