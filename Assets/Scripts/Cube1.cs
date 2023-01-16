using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Cube1 : MonoBehaviour
{

    [SerializeField]
    private Vector3 triangleSize = new Vector3(5, 5, 5);

    [SerializeField]
    private int submeshCount = 1;

    



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCube(Material mat)
    {

        int submeshTopIndex = 0;
        int submeshBottomIndex = 0;
        int submeshFrontIndex = 0;
        int submeshBackIndex = 0;
        int submeshLeftIndex = 0;
        int submeshRightIndex = 0;

        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
       
        MeshBuilder meshBuilder = new MeshBuilder(submeshCount);

        //SET POINTS and TRIANGLES

        // ---- POINTS ----

        //top points
        Vector3 t0 = new Vector3(triangleSize.x, triangleSize.y, -triangleSize.z);
        Vector3 t1 = new Vector3(-triangleSize.x, triangleSize.y, -triangleSize.z);
        Vector3 t2 = new Vector3(-triangleSize.x, triangleSize.y, triangleSize.z);
        Vector3 t3 = new Vector3(triangleSize.x, triangleSize.y, triangleSize.z);

        //bottom points
        Vector3 b0 = new Vector3(triangleSize.x, -triangleSize.y, -triangleSize.z);
        Vector3 b1 = new Vector3(-triangleSize.x, -triangleSize.y, -triangleSize.z);
        Vector3 b2 = new Vector3(-triangleSize.x, -triangleSize.y, triangleSize.z);
        Vector3 b3 = new Vector3(triangleSize.x, -triangleSize.y, triangleSize.z);


        // ---- TRIANGLES ----

        //top square
        meshBuilder.TriangleBuilder(t0, t1, t2, submeshTopIndex);
        meshBuilder.TriangleBuilder(t0, t2, t3, submeshTopIndex);

        //bottom square
        meshBuilder.TriangleBuilder(b2, b1, b0, submeshBottomIndex);
        meshBuilder.TriangleBuilder(b3, b2, b0, submeshBottomIndex);

        //back square
        meshBuilder.TriangleBuilder(t1, t0, b1, submeshBackIndex);
        meshBuilder.TriangleBuilder(t0, b0, b1, submeshBackIndex);


        //front square
        meshBuilder.TriangleBuilder(b3, t0, t3, submeshFrontIndex);
        meshBuilder.TriangleBuilder(b3, b0, t0, submeshFrontIndex);



        //left square
        meshBuilder.TriangleBuilder(b2, b3, t2, submeshLeftIndex);
        meshBuilder.TriangleBuilder(b3, t3, t2, submeshLeftIndex);

        //right square
        meshBuilder.TriangleBuilder(t1, b1, t2, submeshRightIndex);
        meshBuilder.TriangleBuilder(t2, b1, b2, submeshRightIndex);

        MeshCollider meshc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(10, 10, 10);
        meshc.sharedMesh = meshFilter.mesh;        
        this.GetComponent<MeshRenderer>().material = mat;
        meshFilter.mesh = meshBuilder.CreateMesh();        
    }
}
