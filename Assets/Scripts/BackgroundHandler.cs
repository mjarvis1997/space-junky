using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********

Infintely scroll a list of prefabs
    - Instantiates 3 copies of each prefab at adjacent positions
    - Automatically moves bottom prefab up to the top after it is off screen

Potential Improvements
    - What happens if prefabs are not equally sized?
    - Would it be helpful to customize the distance between each prefab? 
    - Would it be helpful to be able to change numOfPositions? Haven't tested anything besides 3

**********/

public class BackgroundHandler : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/
    public List<GameObject> prefabs;

    /******************** PRIVATE VARIABLES ***************/
    [SerializeField] private float SCROLL_SPEED;
    private List<GameObject[]> gameObjectMatrix = new List<GameObject[]>();
    private Vector3[] positions;
    private Vector3 initialPosition;
    private int numOfPositions = 3;
    private float textureUnitSizeY;
    private float height;
    private float initialSpriteYOffset;

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start() 
    {
        initialPosition = prefabs[0].transform.position;

        // get necessary dimensions
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        initialSpriteYOffset = prefabs[0].transform.position.y;

        // build vectors for the prefab positions
        createVectors();        

        // for each background supplied
        foreach (GameObject pf in prefabs)
        {
            // create clones for each and store GameObject's in a list
            gameObjectMatrix.Add(createPrefabs(pf));
        }
    }

    void Update() 
    {
        foreach (GameObject[] gameObjects in gameObjectMatrix)
        {
            foreach (GameObject go in gameObjects)
            {
                // move pf downwards
                go.transform.position += GlobarVars.VECTOR_DOWN * (SCROLL_SPEED / 100);

                // figuring out how to calculate the screen height
                //Debug.Log("Screen height: " + Screen.height);
                Camera cam = Camera.main;
                float height = 2f * cam.orthographicSize;
                float width = height * cam.aspect;
                

                // not sure how to calculate 670 ... checked manually in editor when it crossed bottom of screen
                if(go.transform.position.y < (-1 * height) + initialSpriteYOffset)
                {
                    go.transform.position += new Vector3(0, textureUnitSizeY * 3, 0);
                }
            }
        }
    }

    /******************** PRIVATE FUNCTIONS ********************/
    private void createVectors()
    {        
        // calculate pf height based on prefab provided        
        Sprite sprite = prefabs[0].GetComponentInChildren<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = (texture.height / sprite.pixelsPerUnit) / 4;

        // initialize array of positions
        positions = new Vector3[numOfPositions];

        // determine positions based on initial position and texture size
        for(int i = 0; i < numOfPositions; ++i)
        {
            positions[i] = new Vector3(initialPosition.x, ((i * textureUnitSizeY) + initialPosition.y), initialPosition.z);
        }
    }

    private GameObject[] createPrefabs(GameObject pf) 
    {
        // initialize array to hold our gameObjects
        GameObject[] gameObjects = new GameObject[numOfPositions];

        for(int i = 0; i < numOfPositions; ++i)
        {
            gameObjects[i] = Instantiate(pf, positions[i], Quaternion.identity);
        }

        return gameObjects;
    }
}
