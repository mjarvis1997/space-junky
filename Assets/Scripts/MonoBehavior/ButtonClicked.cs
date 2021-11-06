using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClicked : MonoBehaviour
{
    public Button btn;
    private int numOfFramesPassed = 0;
    private int rotationCounter = 0;
    private int rotationLimit = 16;
    private int rotationPeriod = 75;
    private Vector3 rotationVector = new Vector3(0,0,0.2f);

    //Animator animator;

	public void LoadMyScene()
    {
		Debug.Log ("You have clicked the (" + btn.name + ") button!");
        if(btn.name == "StartButton")
        {
            SceneManager.LoadScene("Game");
        }

        // add code for other button actions here
	}

    void Start() {
        //animator = GetComponent<Animator>();
        //animator.SetTrigger("isButtonClicked");
    }

    void Update() 
    {
        ++numOfFramesPassed;

        // reverse rotation direction after limit is reached

        if(btn.name == "StartButton") 
        {
            if(rotationCounter >= rotationLimit) 
            {
                rotationVector *= -1;
                rotationCounter = 0;
            }         

            if(numOfFramesPassed >= rotationPeriod) {
                rotateButton(rotationVector);
                ++rotationCounter;
                numOfFramesPassed = 0;
            } 
        }
        else if (btn.name == "SettingsButton")
        {
            if(rotationCounter >= (rotationLimit * 1.5)) 
            {
                rotationVector *= -1;
                rotationCounter = 0;
            }         

            if(numOfFramesPassed >= (rotationPeriod * 0.5) ) {
                rotateButton(rotationVector);
                ++rotationCounter;
                numOfFramesPassed = 0;
            } 
        }
        else if (btn.name == "JunkButton")
        {
            if(rotationCounter >= (rotationLimit * 1.2)) 
            {
                rotationVector *= -1;
                rotationCounter = 0;
            }         

            if(numOfFramesPassed >= (rotationPeriod * 0.8) ) {
                rotateButton(rotationVector);
                ++rotationCounter;
                numOfFramesPassed = 0;
            } 
        }
    }

    void rotateButton(Vector3 v) {
        btn.transform.Rotate(v, Space.Self);
    }
}
