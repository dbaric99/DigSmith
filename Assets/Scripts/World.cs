using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public Material material;
    public BlockType[] blockTypes;
}
// block texture pattern: back, front, top, bottom, left, right
[System.Serializable]
public class BlockType
{
    public string name;
    public bool isSolid;
}
