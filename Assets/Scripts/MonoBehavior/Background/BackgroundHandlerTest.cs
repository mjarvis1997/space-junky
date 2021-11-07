using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********

Infintely scroll a list of scrollingObjects
    - Each scrollingObject contains a prefab and some settings to control it's behavior
    - Instantiates 3 copies of each prefab at adjacent positions
    - Automatically moves bottom prefab up to the top after it is off screen

Potential Improvements
    - What happens if prefabs are not equally sized?
    - Would it be helpful to customize the distance between each prefab? 
    - Would it be helpful to be able to change numOfPositions? Haven't tested anything besides 3

**********/

public class BackgroundHandlerTest : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/
    [SerializeField] public List<ScrollingObject> scrollingObject;

    /******************** PRIVATE VARIABLES ***************/
    private List<ScrollingObject[]> gameObjectMatrix = new List<ScrollingObject[]>();
    private Vector3[] positions;
    private Vector3 initialPosition;
    private int numOfPositions = 3;
    private float textureUnitSizeY;
    private float height;
    private float initialSpriteYOffset;

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Start() 
    {
        initialPosition = scrollingObject[0].go.GetComponentInChildren<Transform>().position;

        // get necessary dimensions
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        initialSpriteYOffset = scrollingObject[0].go.transform.position.y;

        // build vectors for the prefab positions
        createVectors();        

        // for each scrolling object supplied
        foreach (ScrollingObject so in scrollingObject)
        {
            // create clones for each and store ScrollingObject's in a list
            gameObjectMatrix.Add(createPrefabs(so));
        }
    }

    void Update() 
    {
        foreach (ScrollingObject[] scrollingObject in gameObjectMatrix)
        {
            foreach (ScrollingObject so in scrollingObject)
            {
                // move pf downwards
                so.go.transform.position += Vector3.down * (so.SCROLL_SPEED / 100);

                // figuring out how to calculate the screen height
                //Debug.Log("Screen height: " + Screen.height);
                Camera cam = Camera.main;
                float height = 2f * cam.orthographicSize;
                float width = height * cam.aspect;
                
                // if sprite exists the screen
                if(so.go.transform.position.y < (-1 * height) + initialSpriteYOffset)
                {
                    so.go.transform.position += new Vector3(0, textureUnitSizeY * 3, 0);
                }
            }
        }
    }

    /******************** PRIVATE FUNCTIONS ********************/
    private void createVectors()
    {        
        // calculate pf height based on prefab provided        
        Sprite sprite = scrollingObject[0].go.GetComponentInChildren<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = (texture.height / sprite.pixelsPerUnit) / 4;

        // initialize array of positions
        positions = new Vector3[numOfPositions];

        // determine positions based on initial position and texture size
        for(int i = 0; i < numOfPositions; ++i)
        {
            Debug.Log(initialPosition.y);
            positions[i] = new Vector3(initialPosition.x, ((i * textureUnitSizeY) + initialPosition.y), initialPosition.z);
        }
    }

    private ScrollingObject[] createPrefabs(ScrollingObject so) 
    {
        // initialize array to hold our scrollingObjects
        ScrollingObject[] scrollingObjects = new ScrollingObject[numOfPositions];

        // create a new scrolling objects based on their individual values and calculated positions
        for(int i = 0; i < numOfPositions; ++i)
        {
            scrollingObjects[i] = new ScrollingObject(Instantiate(so.go, positions[i], Quaternion.identity), so.SCROLL_SPEED);
        }

        return scrollingObjects;
    }
}
