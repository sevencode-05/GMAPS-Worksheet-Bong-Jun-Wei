using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.setIdentity();
        mat.Print();
        Question2();
    }


    public void Question2()
    {
        // Declare matrices and vector
        HMatrix2D mat1 = new HMatrix2D(
            1.0f, 2.0f, 1.0f,
            0.0f, 1.0f, 0.0f,
            2.0f, 3.0f, 4.0f
        );

        HMatrix2D mat2 = new HMatrix2D(
            2.0f, 5.0f, 1.0f,
            6.0f, 7.0f, 1.0f,
            1.0f, 8.0f, 1.0f
        );

        HVector2D vec1 = new HVector2D { x = 2.0f, y = 6.0f, h = 1.0f };

        // Test matrix multiplication
        HMatrix2D resultMat1 = mat1 * mat2;
        HVector2D resultVec1 = mat1 * vec1;

        // Display the results in the console
        resultMat1.Print();
        Debug.Log("Result of mat1 * vec1: (" + resultVec1.x + ", " + resultVec1.y + ", " + resultVec1.h + ")");
    }


}
