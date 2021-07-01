using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;


    int bteta = 10;
    int bphi = 10;
    float tetaIntervall = 2*(Mathf.PI);
    float phiIntervall = 2*(Mathf.PI);

    int radiusErde = 10;
    int layerErde = 10; // Wie viele Blöcke im Erdradius sind. Standart 10 Blöcke im Radius von 10.

    int rb = 1;

    int vertexIndex = 0;


    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        tetaIntervall = bteta/2*(Mathf.PI);
        phiIntervall = bphi/2*(Mathf.PI);
        rb = radiusErde/layerErde;
        vertices = new List<Vector3>();
        triangles = new List<int>();

        CreateShape();
        CreateMesh();
    }

    void CreateShape() {

        for (int k = rb; k <= radiusErde ; k++) { // Erdradius layer
            for (int i = 0; i < bteta; i++) {
                for (int j = 0; j < bphi; j++)
                {
                    // Später kompakter coden 
                    verticesGenerator(k,i,j);
                    trianglesGenerator();

                }
                
            }
        }

        /*

        vertices = new Vector3[] {

            // Punkt A
            float X = rb*(k+0) * Math.cos(bteta*(i+0)) * Math.cos(bphi*(j+0));
            float Y = rb*(k+0) * Math.cos(bteta*(i+0)) * Math.sin(bphi*(j+0));
            float Z = rb*(k+0) * Math.sin(bteta*(i+0));
            
            new Vector3(X,Y,Z) // Punkt A 

            

            new Vector3(0,0,0),
            new Vector3(0,0,0),
            new Vector3(0,0,0)
        };*/
    }
    // Update is called once per frame


    void verticesGenerator(int k, int i, int j) { // Vertices eines Voxels
        float X = rb*(k+0) * Mathf.Cos(bteta*(i+0)) * Mathf.Cos(bphi*(j+0));
                    float Y = rb*(k+0) * Mathf.Cos(bteta*(i+0)) * Mathf.Sin(bphi*(j+0));
                    float Z = rb*(k+0) * Mathf.Sin(bteta*(i+0));
            
                     // Punkt A 
                    vertices.Add(new Vector3(X,Y,Z));

                    X = rb*(k+0) * Mathf.Cos(bteta*(i+1)) * Mathf.Cos(bphi*(j+0));
                    Y = rb*(k+0) * Mathf.Cos(bteta*(i+1)) * Mathf.Sin(bphi*(j+0));
                    Z = rb*(k+0) * Mathf.Sin(bteta*(i+1));
            
                     // Punkt B
                    vertices.Add(new Vector3(X,Y,Z));

                    X = rb*(k+1) * Mathf.Cos(bteta*(i+0)) * Mathf.Cos(bphi*(j+0));
                    Y = rb*(k+1) * Mathf.Cos(bteta*(i+0)) * Mathf.Sin(bphi*(j+0));
                    Z = rb*(k+1) * Mathf.Sin(bteta*(i+0));
            
                     // Punkt C
                    vertices.Add(new Vector3(X,Y,Z));

                    X = rb*(k+1) * Mathf.Cos(bteta*(i+1)) * Mathf.Cos(bphi*(j+0));
                    Y = rb*(k+1) * Mathf.Cos(bteta*(i+1)) * Mathf.Sin(bphi*(j+0));
                    Z = rb*(k+1) * Mathf.Sin(bteta*(i+1));
            
                     // Punkt D
                    vertices.Add(new Vector3(X,Y,Z));

                    X = rb*(k+0) * Mathf.Cos(bteta*(i+0)) * Mathf.Cos(bphi*(j+1));
                    Y = rb*(k+0) * Mathf.Cos(bteta*(i+0)) * Mathf.Sin(bphi*(j+1));
                    Z = rb*(k+0) * Mathf.Sin(bteta*(i+0));
            
                     // Punkt E
                    vertices.Add(new Vector3(X,Y,Z));

                    X = rb*(k+0) * Mathf.Cos(bteta*(i+1)) * Mathf.Cos(bphi*(j+1));
                    Y = rb*(k+0) * Mathf.Cos(bteta*(i+1)) * Mathf.Sin(bphi*(j+1));
                    Z = rb*(k+0) * Mathf.Sin(bteta*(i+1));
            
                     // Punkt F 
                    vertices.Add(new Vector3(X,Y,Z));

                    X = rb*(k+1) * Mathf.Cos(bteta*(i+0)) * Mathf.Cos(bphi*(j+1));
                    Y = rb*(k+1) * Mathf.Cos(bteta*(i+0)) * Mathf.Sin(bphi*(j+1));
                    Z = rb*(k+1) * Mathf.Sin(bteta*(i+0));
            
                     // Punkt G 
                    vertices.Add(new Vector3(X,Y,Z));

                    X = rb*(k+1) * Mathf.Cos(bteta*(i+1)) * Mathf.Cos(bphi*(j+1));
                    Y = rb*(k+1) * Mathf.Cos(bteta*(i+1)) * Mathf.Sin(bphi*(j+1));
                    Z = rb*(k+1) * Mathf.Sin(bteta*(i+1));
            
                     // Punkt H 
                    vertices.Add(new Vector3(X,Y,Z));
    }

    void trianglesGenerator(){ // alle 6 Seiten des Voxels mit Triangles
        //for (int i=0; i<6; i++) {
            int i = 0;
            triangles.Add(vertexIndex + i);
            triangles.Add(vertexIndex + i+2);
            triangles.Add(vertexIndex + i+1);
            triangles.Add(vertexIndex + i+2);
            triangles.Add(vertexIndex + i+3);
            triangles.Add(vertexIndex + i+1); //ACB CDB = 021 231

            vertexIndex += 4;
        //}
        
    }
    void CreateMesh() {  // Mesh wird nun im mesh gespeichert und kann angezeigt werden.
        Mesh mesh = new Mesh() { // Object initialisierung
            vertices = vertices.ToArray(),
            triangles = triangles.ToArray(),
        };
        //mesh.RecalculateNormals(); // Jedes Vertices hat einen Normalenvektor der in einer Richtung zeigt
    }

    void Update()
    {
        
    }
}
