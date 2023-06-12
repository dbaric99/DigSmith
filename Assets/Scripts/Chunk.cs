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

    void Start()
    {

        AddVoxelToChunk();
        CreateMesh();

    }

    void AddVoxelToChunk(Vector3 position)
    {
        for (int j = 0; j < SIDES_NUMBER; j++)
        {
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
}
