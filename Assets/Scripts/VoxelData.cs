using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData
{
    public static readonly Vector3[] voxelVertices = new Vector3[8] {

        new Vector3(0.0f,0.0f,0.0f), // --> 0
        new Vector3(1.0f,0.0f,0.0f), // --> 1
        new Vector3(1.0f,1.0f,0.0f), // --> 2
        new Vector3(0.0f,1.0f,0.0f), // --> 3
        new Vector3(0.0f,0.0f,1.0f), // --> 4
        new Vector3(1.0f,0.0f,1.0f), // --> 5
        new Vector3(1.0f,1.0f,1.0f), // --> 6
        new Vector3(0.0f,1.0f,1.0f)  // --> 7
    
    };

    public static readonly int[] voxelTriangles = new int[1, 6] {

        {3,7,2,2,7,6}, //Top Square


    };
}
