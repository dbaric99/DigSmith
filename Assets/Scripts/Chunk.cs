using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;
    const int SIDES_NUMBER = 6;
    void Start()
    {
        int vertexIndex = 0;
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        for (int j = 0; j < SIDES_NUMBER; j++)
        {
            for (int i = 0; i < SIDES_NUMBER; i++)
            {
                int triangleIndex = VoxelData.voxelTriangles[j, i];
                vertices.Add(VoxelData.voxelVertices[triangleIndex]);
                triangles.Add(vertexIndex);
                uvs.Add(Vector2.zero);
                vertexIndex++;
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
    }
}
