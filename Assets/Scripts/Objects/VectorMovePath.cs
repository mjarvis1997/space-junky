using System;
using UnityEngine;

[Serializable]
public class VectorMovePath
{
    public float MOVE_SPEED;
    public float MOVE_DISTANCE;
    public Vector3 MOVE_DIR;
   
   public VectorMovePath(float MOVE_SPEED, float MOVE_DISTANCE, Vector3 MOVE_DIR)
   {
       this.MOVE_SPEED = MOVE_SPEED;
       this.MOVE_DISTANCE = MOVE_DISTANCE;
       this.MOVE_DIR = MOVE_DIR;
   }
}
