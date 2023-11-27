using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
 {
     public Vector3 force;
     Rigidbody rb;

    void Start()
     {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(1,0,0, ForceMode.Impulse);
     }

     void FixedUpdate()
     {
         Debug.Log(transform.position);
     }
}

