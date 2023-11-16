using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        setIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        //do error checking
        for (int y =0; y < 3; y++)
        {
            for (int x =0; x < 3; x++)
            {
                entries[x,y] = multiArray[x,y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        entries[0,0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;

    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        // Create a new HMatrix2D to store the result
        HMatrix2D result = new HMatrix2D();

        // Loop through the rows and columns of the matrices
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // Add the corresponding elements from the left and right matrices
                result.entries[y, x] = left.entries[y, x] + right.entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        // Create a new HMatrix2D to store the result
        HMatrix2D result = new HMatrix2D();

        // Loop through the rows and columns of the matrices
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // Add the corresponding elements from the left and right matrices
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }
        }

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        // Create a new HMatrix2D to store the result
        HMatrix2D result = new HMatrix2D();

        // Loop through the rows and columns of the matrix
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                // Multiply each element of the matrix by the scalar value
                result.entries[y, x] = left.entries[y, x] * scalar;
            }
        }

        return result;
    }

    // Note that the second argument is a HVector2D object
    //
    //public static HVector2D operator *(HMatrix2D left, HVector2D right)
    //{
        //return // your code here
    //}

    // Note that the second argument is a HMatrix2D object
    //
    //public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    //{
        //return new HMatrix2D
        //(
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
    //);
    //}

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        // your code here

        for(int y = 0; y <3; y++)
        {
            for( int x = 0; x<3; x++)
            {
                if (left.entries[y,x] != right.entries[y, x])
                {
                    return false;
                }
            }
        }

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

        for (int y = 0; y < entries.GetLength(0); y++)
        {
            for (int x = 0; x < entries.GetLength(1); x++)
            {
                entries[y, x] = (x == y) ? 1 : 0;
            }
        }

    }

    public void setTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void setRotationMat(float rotDeg)
    {
        // your code here
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
