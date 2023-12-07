//// Uncomment this whole file.

//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();



    void Start()
    {
        //get the meshManager component from the object with the scirpt attached to oit 
        meshManager = GetComponent<MeshManager>();
        // create an instance of HVector2D passing, the gameobect position.x and gameobject position.y 
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        // Your code here
        Translate(1, 1);
        //Rotate(90f);

    }


    void Translate(float x, float y)
    {
        //set toOriginMatrix to an identity matrix 
        toOriginMatrix.setIdentity();
        //set the translation by x,y
        toOriginMatrix.setTranslationMat(x, y);
        //apply the translation to the mesh vertices 
        Transform();

        //update the object position by the product of the below
        pos = toOriginMatrix * pos;
        
    }

    void Rotate(float angle)
    {
        //set toOriginMatrix to the translation to the origin
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        //set fromOriginMatrix to translation from the origin
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);
        
        //set rotateMatrix to roatae by the specific angle
        //angle taken in as the parameter to the Rotate function
        rotateMatrix.setRotationMat(angle);

        //resets the transfromMatrix to identity matrix 
        transformMatrix.setIdentity();
        //combine translation to the origin, rotation and translation from the origin
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        //apply the combined transformation to the mesh vertices
        Transform();
    }

    private void Transform()
    {
        //takes in the cloned mesh vertices 
        vertices = meshManager.clonedMesh.vertices;

        // iterate through each vertex in the array 
        for (int i = 0; i < vertices.Length; i++)
        {
            //new instance of HVector2D that takes in the x and y position of the current vertex position in the array
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);

            //apply translation matrix
            //moving the vertex to the origin
            vert = toOriginMatrix * vert;

            //applies rotation matirx
            //rotate the vertex
            vert = rotateMatrix * vert;

            //update the x and y position of the vertex in the array with the newly updated transformed value  
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        // updates the vertices of the clones mesh with the updated transformed positions
        meshManager.clonedMesh.vertices = vertices;
    }
}
