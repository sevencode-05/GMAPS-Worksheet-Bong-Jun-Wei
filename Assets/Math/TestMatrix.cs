using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        //testing of the digonal matrix from the function setIdentity()
        mat.setIdentity();
        //print the matrix
        mat.Print();
        Question2();
    }


    public void Question2()
    {
        //declare the first matrix 
        // with the values initialized into it
        //values from the website provided in the worksheet
        HMatrix2D mat1 = new HMatrix2D(
            1.0f, 2.0f, 1.0f,
            0.0f, 1.0f, 0.0f,
            2.0f, 3.0f, 4.0f
        );

        //declare the second matrix 
        // with the values initialized into it
        //values from the website provided in the worksheet
        HMatrix2D mat2 = new HMatrix2D(
            2.0f, 5.0f, 1.0f,
            6.0f, 7.0f, 1.0f,
            1.0f, 8.0f, 1.0f
        );
        
        //declare new instance of HVector2D
        //with the values initialized into the x,y,z component
        //values from the website from the worksheet
        HVector2D vec1 = new HVector2D { x = 2.0f, y = 6.0f, h = 1.0f };

        //result of the matrix mulitplication 
        HMatrix2D resultMat1 = mat1 * mat2;
        //result of the maxtrix vector muliplication
        HVector2D resultVec1 = mat1 * vec1;

        //result of the matrix mulipicaltion printed out in console using Print() function
        resultMat1.Print();
        //result of the matrix vector muliplication printed out in the console
        //using Debug.Log as Print(), does not accept 
        Debug.Log("Result of mat1 * vec1: (" + resultVec1.x + ", " + resultVec1.y + ", " + resultVec1.h + ")");
    }


}
