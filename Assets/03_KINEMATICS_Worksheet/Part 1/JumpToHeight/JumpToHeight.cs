 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class JumpToHeight : MonoBehaviour
 {
    //declaring the height variable 
     public float Height = 1f;
    //declaring the rigidbody variable
     Rigidbody rb;

     private void Start()
     {
        //gets the rigidbody component from the object which this script is attached to 
         rb = GetComponent<Rigidbody>();
     }

     void Jump()
     {
        //v*v = u*u + 2as
        //u*u = v*v - 2as
        //u = sqrt(v*v - 2as)
        //v = 0, u = ?, a = Physics.gravity, s = Height

        // u is the initial velocity
        // to calculate it, we use this equation (u = sqrt(v*v - 2as))
        //put in the valuse after rearranging the formula
        //using y for physics.gravity.y because we will want the object to jump - hence move upwards along the y axis 
        float u = Mathf.Sqrt(0-2 * Physics.gravity.y * Height);
        //set the object velocity to the y value we calculate for it to move/jump upwards
        rb.velocity = new Vector3(0, u, 0);

        
     }

     private void Update()
     {
        //if space bar is being pushed down/use
         if(Input.GetKeyDown(KeyCode.Space))
         {
            //call the jump function to let the boxes in the scene jump
             Jump();
         }
     }
 }

