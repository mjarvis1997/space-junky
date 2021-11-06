using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    /******************** PUBLIC VARIABLES ***************/
    public GameObject Canvas;
    public Text TextTimer;
    public Timer timer;

    /******************** STANDARD UNITY FUNCTIONS ********************/
    void Update()
    {
        // timer text
        TextTimer.text = timer.inGameTime.ToString("0.0");

    }
}
