using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/
    public float inGameTime = 0.0f;

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Update()
    {
        // update timer
        inGameTime += Time.deltaTime;
    }
}
