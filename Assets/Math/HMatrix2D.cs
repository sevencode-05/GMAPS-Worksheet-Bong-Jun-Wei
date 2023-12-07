using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using UnityEngine;

public class HMatrix2D
{
    //declare entries and let it be a 2D float array which is 3x3
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        //call the SetIdentity function to initialize the object
        setIdentity();
    }


    public HMatrix2D(float[,] multiArray)
    {
        //y being the row - outer loop
        //iterates over the rows of this matrix
        for (int y =0; y < 3; y++)
        {
            //x being the colums - inner loop
            //iterates over the number of columns of matrix 
            for (int x =0; x < 3; x++)
            {
                //assigning the position to its value
                entries[x,y] = multiArray[x,y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        //basically just hardcoding 
        //putting in the values for the matrix 
        //putting in the values in the first row
        entries[0,0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        //putting in the values in the second row
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        //putting in the values in the third row
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;

    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        //create a new instance of HMatrix2D called result  
        HMatrix2D result = new HMatrix2D();

        // Loop through the rows of the matrix 
        for (int y = 0; y < 3; y++)
        {
            //loop through the columns of the matrix
            for (int x = 0; x < 3; x++)
            {
                //add the corresponding elements from the left and right matrix
                result.entries[y, x] = left.entries[y, x] + right.entries[y, x];
            }
        }

        //retun the product of the additional of both matrix 
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        //create a new instance of HMatrix2D called result  
        HMatrix2D result = new HMatrix2D();

        // Loop through the rows of the matrix 
        for (int y = 0; y < 3; y++)
        {
            //loop through the columns of the matrix
            for (int x = 0; x < 3; x++)
            {
                //subtract the corresponding elements from the left and right matrices
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }
        }

        //retun the product of the substraction of both matrix 
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        //create a new instance of HMatrix2D called result  
        HMatrix2D result = new HMatrix2D();

        // Loop through the rows of the matrix 
        for (int y = 0; y < 3; y++)
        {
            //loop through the columns of the matrix
            for (int x = 0; x < 3; x++)
            {
                //mulitply the corresponding elements from matrix and scalar
                result.entries[y, x] = left.entries[y, x] * scalar;
            }
        }

        //retun the product of the multiplication of matrix and scalar
        return result;
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        //create a new HVector2D instance to store the results
        return new HVector2D
        (
            //calculate the x of the resulting vecotr
            left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h,
            //calculate the y component of the resulting vector
            left.entries[0, 1] * right.y + left.entries[1, 2] * right.h

        );

    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
        /* 
            00 01 02    00 xx xx
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
        //left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

        /* 
            00 01 02    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
        //left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

        // and so on for another 7 entries


        // Row 0
        left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
        left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
        left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

        // Row 1
        left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
        left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
        left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

        // Row 2
        left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
        left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
        left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]



        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        
        //for loop through the rows of the matrice
        for(int y = 0; y <3; y++)
        {
            //for loop through the column of the matrice 
            for( int x = 0; x<3; x++)
            {
                //if the pair of element from left and right matrix are not equal 
                if (left.entries[y,x] != right.entries[y, x])
                {
                    //return boolean value of False 
                    return false;
                }
            }
        }

        //return boolean value of True when both of the matrix, left and right are identical 
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.entries[y, x] == right.entries[y, x])
                {
                    return true;
                }
            }
        }

        return false;
    }

    //public override bool Equals(object obj)
    //{
        // your code here
    //}

    //public override int GetHashCode()
    //{
        // your code here
    //}

    //public HMatrix2D transpose()
    //{
        //return // your code here
    //}

    //public float getDeterminant()
    //{
        //return // your code here
    //}

    public void setIdentity()
    {
        //for (int y = 0; y < entries.GetLength(0); y++)
        //{
        //for (int x = 0; x < entries.GetLength(1); x++)
        //{
        //if (x == y)
        //{
        //entries[y,x] = 1;
        //}
        //else
        //{
        //entries[y,x] = 0;
        //}
        //}
        //}

        // for loop through the number of rows in the matrix 
        //increment of 1 every loop
        for (int y = 0; y < entries.GetLength(0); y++)
        {
            //for loop over the number of columns in the matrix 
            for (int x = 0; x < entries.GetLength(1); x++)
            {
                //using the ternary operator 
                //making the code clearer in a way - shorter code 
                //if index x = y which is the digonal element 
                //assign the value 1 to it
                //else, assign the value 0 to it
                entries[y, x] = (x == y) ? 1 : 0;
            }
        }

    }

    public void setTranslationMat(float transX, float transY)
    {
        //reset the matrix to identity matrix before applying the translation
        setIdentity();

        //set the translation along the x axis
        entries[0, 2] = transX;
        //set the translation along the y axis
        entries[1, 2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {
        //reset the matrix to identity matrix before applying rotation
        setIdentity();
        //converting the roatation from degree to radians
        float rad = rotDeg * Mathf.Deg2Rad;
        //cosine of the angle from the top left element
        entries[0, 0] = Mathf.Cos(rad);
        //negative sine of the angle from the top right element 
        entries[0, 1] = -Mathf.Sin(rad);
        //sine of the angle from the bottom left elemnt 
        entries[1, 0] = Mathf.Sin(rad);
        //cosine of the rotation angle for the bottom right element
        entries[1, 1] = Mathf.Cos(rad);
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
