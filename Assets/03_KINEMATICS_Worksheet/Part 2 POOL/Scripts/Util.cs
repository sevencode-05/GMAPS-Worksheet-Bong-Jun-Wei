using System.Collections;
 using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

 public class Util
 {
    

    
    

     public static float FindDistance(HVector2D p1, HVector2D p2)
     {
        //using pythagorean theorem to calcuate the distance between 2 points
         return (float)Mathf.Sqrt(Mathf.Pow(p2.x - p1.x, 2) + Mathf.Pow(p2.y - p1.y, 2));
    }

   


}


