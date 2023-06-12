using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;
    const int SIDES_NUMBER = 6;

    int vertexIndex = 0;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();
    bool[,,] voxelMap = new bool[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];

    void Start()
    {
        FillVoxelMap();
        CreateChunk();
        CreateMesh();

    }

    void AddVoxelToChunk(Vector3 position)
    {
        for (int j = 0; j < SIDES_NUMBER; j++)
        {
            if (HasNeighbour(position + VoxelData.checks[j])) continue;
            for (int i = 0; i < SIDES_NUMBER; i++)
            {
                int triangleIndex = VoxelData.voxelTriangles[j, i];
                vertices.Add(VoxelData.voxelVertices[triangleIndex] + position);
                triangles.Add(vertexIndex);

                uvs.Add(VoxelData.voxelUvs[i]);
                vertexIndex++;
            }
        }
    }

    void CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
    }

    void FillVoxelMap()
    {
        for (int y = 0; y < VoxelData.ChunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.ChunkWidth; x++)
            {
                for (int z = 0; z < VoxelData.ChunkWidth; z++)
                {
                    //TODO refactor
                    voxelMap[x, y, z] = true;
                }
            }
        }
    }

    bool HasNeighbour(Vector3 position)
    {
        var positionCoords = (
        x: Mathf.FloorToInt(position.x),
        y: Mathf.FloorToInt(position.y),
        z: Mathf.FloorToInt(position.z)
        );

        // Check if index is out of range
        if (positionCoords.x < 0 || positionCoords.x > VoxelData.ChunkWidth - 1 ||
            positionCoords.y < 0 || positionCoords.y > VoxelData.ChunkHeight - 1 ||
            positionCoords.z < 0 || positionCoords.z > VoxelData.ChunkWidth - 1)
            return false;

        return voxelMap[positionCoords.x, positionCoords.y, positionCoords.z];
    }

    void CreateChunk()
    {

    }
}
