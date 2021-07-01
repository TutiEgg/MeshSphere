using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSphere: MonoBehaviour {

    public MeshRenderer meshRenderer; // SPeichert Texturen (Material)
    public MeshFilter meshFilter;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

    void Start() {
        
        int vertexIndex = 0;
        for (int j = 0; j < 6; j++) {
            for (int i = 0; i < 6; i++) {
            int triangleIndex = MeshOneVoxel.voxelTris[j,i];
            vertices.Add(MeshOneVoxel.voxelVerts[triangleIndex]);

            

            uvs.Add(Vector2.zero);
            
            triangles.Add(vertexIndex);
            
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
