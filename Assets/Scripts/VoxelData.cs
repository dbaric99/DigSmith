using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData
{
    public static readonly int ChunkWidth = 5;
    public static readonly int ChunkHeight = 15;
    public static readonly int AtlasSize = 4;
    public static float BlockTextureSize = 1.0f / (float)AtlasSize;

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

    public static readonly Vector3[] checks = new Vector3[6] {
        new Vector3(0.0f, 0.0f, -1.0f), //Back Square
        new Vector3(0.0f, 0.0f, 1.0f), //Front Square
        new Vector3(0.0f, 1.0f, 0.0f), //Top Square
        new Vector3(0.0f, -1.0f, 0.0f), //Bottom Square
        new Vector3(-1.0f, 0.0f, 0.0f), //Left Square
        new Vector3(1.0f, 0.0f, 0.0f) //Right Square
    };

    public static readonly int[,] voxelTriangles = new int[6, 4] {
        // pattern indexes(loops back): 0 1 2 2 1 3
        {0, 3, 1, 2}, //Back Square
        {5, 6, 4, 7}, //Front Square
        {3, 7, 2, 6}, //Top Square
        {1, 5, 0, 4}, //Bottom Square
        {4, 7, 0, 3}, //Left Square
        {1, 2, 5, 6} //Right Square
    };

    public static readonly Vector2[] voxelUvs = new Vector2[6] {
        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 1.0f)
    };
}
