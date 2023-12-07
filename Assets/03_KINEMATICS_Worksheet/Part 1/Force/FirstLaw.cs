using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
 {
     public Vector3 force;
     Rigidbody rb;

    void Start()
     {
        //get the rigidbody component from the object that the script is attached to
        rb = GetComponent<Rigidbody>();
        //applying a force at the object's x position.
        //using a impluse force indicates that it is a one time force 
        //thus, the object will be moving at constant velocity
        rb.AddForce(1,0,0, ForceMode.Impulse);
     }

     void FixedUpdate()
     {
        //prints out the object position in the console.
         Debug.Log(transform.position);
     }
}

