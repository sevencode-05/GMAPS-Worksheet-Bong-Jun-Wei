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
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        // Your code here
        Translate(1, 1);
        //Rotate(90f);

    }


    void Translate(float x, float y)
    {
        toOriginMatrix.setIdentity();
        toOriginMatrix.setTranslationMat(x, y);
        Transform();

        pos = toOriginMatrix * rotateMatrix * pos;
        
    }

    void Rotate(float angle)
    {
        //HMatrix2D toOriginMatrix = new HMatrix2D();
        //HMatrix2D fromOriginMatrix = new HMatrix2D();
        //HMatrix2D rotateMatrix = new HMatrix2D();

        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        rotateMatrix.setRotationMat(angle);

        transformMatrix.setIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        // Apply transformations to each vertex
        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);

            // Apply the translation matrix (toOriginMatrix)
            vert = toOriginMatrix * vert;

            vert = rotateMatrix * vert;

            // Update the vertex positions in the array
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        // Update the vertices of the cloned mesh
        meshManager.clonedMesh.vertices = vertices;
    }
}
