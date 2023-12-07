using System.Collections;
using System.Collections.Generic;using UnityEngine;

public class Motion : MonoBehaviour
{
     public Vector3 Velocity;

     void FixedUpdate()
     {
        //calculates the time elsaped since the last frame
        float dt = Time.deltaTime;

        //calculate the displacment based on the x, y, z component of the velocity with the time elsaped respectively
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        //moving the object by giving it the force/displacement calulated previosuly
        transform.Translate(new Vector3(dx, dy, dz));
    }
 }
