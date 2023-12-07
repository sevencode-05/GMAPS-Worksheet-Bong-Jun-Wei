 using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
public class Ball2D : MonoBehaviour
{
    //declare these 2 variables to be the object positions and velocity
     public HVector2D Position = new HVector2D(0, 0);
     public HVector2D Velocity = new HVector2D(0, 0);
    
    //the radius of the ball 
     [HideInInspector]
     public float Radius;


    //Tesing whether the FindDtistance form sciript Util works. 
    //HVector2D a = new HVector2D(8f, 2f);
    //HVector2D b = new HVector2D(1f, 3f);



    private void Start()
     {
        //initialize the position variable of the ball with its current x and y coordiantes in the unity scene
         Position.x = transform.position.x;
         Position.y = transform.position.y;

        //get the sprite component from the object which this script is attanched to 
         Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        //size of the sprite's rectangle in pixel
         Vector2 sprite_size = sprite.rect.size;
        //convert the sprite size from pixels into unity units
         Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        //caculate the radius of the ball by taking half the width of the converted sprite size
         Radius = local_sprite_size.x / 2f;

        //Tesing whether the FindDtistance form sciript Util works. 
        //float distance = Util.FindDistance(a, b);
        //Debug.Log(distance);


    }

     public bool IsCollidingWith(float x, float y)
     {
        //using pythangorean theorem to calulate the distance of the mouse, and center of the ball 
         float distance = Mathf.Sqrt(Mathf.Pow(x - Position.x, 2) + Mathf.Pow(y - Position.y, 2));
        //return true when the distance is equal or less than the ball radius
        //indicating that the mouse is tab inside the ball 
        return distance <= Radius;
     }

//     public bool IsCollidingWith(Ball2D other)
//     {
//         float distance = Util.FindDistance(Position, other.Position);
//         return distance <= Radius + other.Radius;
//     }

     public void FixedUpdate()
     {
        //updating the physics of the ball using the fixed time interval 
         UpdateBall2DPhysics(Time.deltaTime);
     }

     private void UpdateBall2DPhysics(float deltaTime)
     {
        //calcuate the displacement in x and y respectiviy based on the velocity and time 
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //update the object position with the displacement calcuated 
        Position.x += displacementX;
        Position.y += displacementY;

        //update the transform of the ball object to let it have its new position 
        transform.position = new Vector2(Position.x, Position.y);
    }
 }

