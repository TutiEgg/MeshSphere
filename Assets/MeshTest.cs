using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour
{

    public MeshRenderer meshRenderer; // SPeichert Texturen (Material)
    public MeshFilter meshFilter;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();


    // Start is called before the first frame update
    void Start()
    {
        int vertexIndex = 0;
    for(int p = 1; p < 6; p++){
    
        for (int j = 0; j < 6; j++) {
            for (int i = 0; i < 6; i++) {
            int triangleIndex = Voxel.voxelTris[j,i];

            vertices.Add(Voxel.voxelVerts[triangleIndex] * p);

            

            //uvs.Add(Vector2.zero);
            
            triangles.Add(vertexIndex);
            
            vertexIndex++;

            }
        }
        Voxel.kradius++;
        Debug.Log("Hier: "+ Voxel.voxelVerts[7]);
    }

            
        
        

        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        //mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }

    
}
