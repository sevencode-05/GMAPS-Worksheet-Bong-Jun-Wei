 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
using UnityEngine.UIElements;

public class PoolCue : MonoBehaviour
 {
 	public LineFactory lineFactory;
 	public GameObject ballObject;

 	private Line drawnLine;
 	private Ball2D ball;

 	private void Start()
 	{
 		ball = ballObject.GetComponent<Ball2D>();
 	}

 	void Update()
 	{
        if (Input.GetMouseButtonDown(0))
        {
            //mouse position in the game scene/world when it is being pressed by the user
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //check whether the ball object exists and the mouse click is inside the ball object
            //by using the IsCollidingWIth() function created earlier 

            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
            {
                //create the line using the GetLine function from lineFaactory
                //start point being the mouse position 
                //end point being the ball object position
                //set the line width to 2.0f, and line color to white 
                drawnLine = lineFactory.GetLine(startLinePos, ballObject.transform.position, 2.0f, Color.white);
                //enable drawing of line
                drawnLine.EnableDrawing(true);

                //testing
                //Debug.Log("Inside the ball");

            }
        }
        //when the left mouse button is released
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            //set the drawing of line to false
            //so that no line is drawn
            drawnLine.EnableDrawing(false);



            //update the velocity of the white ball basing on the line (vector) we draw earlier 
            //controls the direction of the vector
            HVector2D v = new HVector2D(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);

            //set the ball velociy to v which is the velocity of the ball 
            ball.Velocity = v;
            //end line drawing 
            drawnLine = null;
        }

        //if the drawn line is active 
 		if (drawnLine != null)
 		{
            //update the end point of the drawn line to the current mouse position 
 			drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
 	}

// 	/// <summary>
// 	/// Get a list of active lines and deactivates them.
// 	/// </summary>
// 	public void Clear()
// 	{
// 		var activeLines = lineFactory.GetActive();

// 		foreach (var line in activeLines)
// 		{
// 			line.gameObject.SetActive(false);
// 		}
// 	}
 }
