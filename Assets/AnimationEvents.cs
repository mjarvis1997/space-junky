using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void Destroy()
    {
        Debug.Log("animator destroyed something");
        Destroy(gameObject);
    }
}
