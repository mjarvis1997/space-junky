using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConfig
{
    public Vector3 start_pos;
    public Vector3 pos_offset;
    public Quaternion orientation;

    public SpawnConfig( Vector3 start_pos, Vector3 pos_offset, Quaternion orientation)
    {
        this.start_pos = start_pos;
        this.pos_offset = pos_offset;
        this.orientation = orientation;
    }
}
