using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshOneVoxel : MonoBehaviour
{

    static int bteta = 8;
    static int bphi = 8;
    static float intervall = 2*(Mathf.PI);
    static float teta = bteta/intervall;
    static float phi = phi/intervall;
    

    int radiusErde = 10;
    int layerErde = 10; // Wie viele Blöcke im Erdradius sind. Standart 10 Blöcke im Radius von 10.

    static int rb = 1;

    static int k = 1;


    public static readonly Vector3[] voxelVerts = { // 8 ecken hat ein Rechteckiger Block
        // Triangles muss man im Uhrzeigersinn der Richtung zeichnen, damit es in die Richtung angezeigt wird in der man sie haben will. Man sieht ein Mesh nur von einer Seite.

        // Array-Inhalte 0-7 von Rechteck OFFSET werte
        new Vector3(
            rb*(k+0) * Mathf.Cos(teta*(k+0)) * Mathf.Cos(phi*(k+0)), 
            rb*(k+0) * Mathf.Cos(teta*(k+0)) * Mathf.Sin(phi*(k+0)), 
            rb*(k+0) * Mathf.Sin(teta*(k+0))
        ), // 0=A

        new Vector3(
            rb*(k+0) * Mathf.Cos(teta*(k+1)) * Mathf.Cos(phi*(k+0)), 
            rb*(k+0) * Mathf.Cos(teta*(k+1)) * Mathf.Sin(phi*(k+0)), 
            rb*(k+0) * Mathf.Sin(teta*(k+1))
        ), // 1=B

        new Vector3(
            rb*(k+1) * Mathf.Cos(teta*(k+0)) * Mathf.Cos(phi*(k+0)), 
            rb*(k+1) * Mathf.Cos(teta*(k+0)) * Mathf.Sin(phi*(k+0)), 
            rb*(k+1) * Mathf.Sin(teta*(k+0))
        ), // 1=C

        new Vector3(
            rb*(k+1) * Mathf.Cos(teta*(k+1)) * Mathf.Cos(phi*(k+0)), 
            rb*(k+1) * Mathf.Cos(teta*(k+1)) * Mathf.Sin(phi*(k+0)), 
            rb*(k+1) * Mathf.Sin(teta*(k+1))
        ), // 1=D

        new Vector3(
            rb*(k+0) * Mathf.Cos(teta*(k+0)) * Mathf.Cos(phi*(k+1)), 
            rb*(k+0) * Mathf.Cos(teta*(k+0)) * Mathf.Sin(phi*(k+1)), 
            rb*(k+0) * Mathf.Sin(teta*(k+0))
        ), // 1=E

        new Vector3(
            rb*(k+0) * Mathf.Cos(teta*(k+1)) * Mathf.Cos(phi*(k+1)), 
            rb*(k+0) * Mathf.Cos(teta*(k+1)) * Mathf.Sin(phi*(k+1)), 
            rb*(k+0) * Mathf.Sin(teta*(k+1))
        ), // 1=F

        new Vector3(
            rb*(k+1) * Mathf.Cos(teta*(k+0)) * Mathf.Cos(phi*(k+1)), 
            rb*(k+1) * Mathf.Cos(teta*(k+0)) * Mathf.Sin(phi*(k+1)), 
            rb*(k+1) * Mathf.Sin(teta*(k+0))
        ), // 1=G

        new Vector3(
            rb*(k+1) * Mathf.Cos(teta*(k+1)) * Mathf.Cos(phi*(k+1)), 
            rb*(k+1) * Mathf.Cos(teta*(k+1)) * Mathf.Sin(phi*(k+1)), 
            rb*(k+1) * Mathf.Sin(teta*(k+1))
        ), // 1=H

    }; 

    public static readonly int[,]voxelTris = {
        //ACB BCD
        {0,2,1,1,2,3},
        {2,6,3,3,6,7},
        {4,0,5,5,0,1},
        {5,7,4,4,7,1},
        {1,3,5,5,3,7},
        {4,6,0,0,6,2}


        //{3,7,2,2,7,6}
    };
}
