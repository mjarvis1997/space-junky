using System;
using UnityEngine;

[Serializable]
public class VectorPath
{
    public float move_speed;
    public float move_distance;
    public Vector3 move_dir;
   
   public VectorPath(float move_speed, float move_distance, Vector3 move_dir)
   {
       this.move_speed = move_speed;
       this.move_distance = move_distance;
       this.move_dir = move_dir;
   }
}
