using System;
using UnityEngine;

[Serializable]
public class ScrollingObject
{
    public GameObject go;
    public float SCROLL_SPEED;

    public ScrollingObject(GameObject go, float SCROLL_SPEED)
    {
        this.go = go;
        this.SCROLL_SPEED = SCROLL_SPEED;
    }
}