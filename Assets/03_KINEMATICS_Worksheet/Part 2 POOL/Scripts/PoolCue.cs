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
 			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
 			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
 			{
                drawnLine = lineFactory.GetLine(startLinePos, Vector2.zero, 2.0f, Color.white);

                drawnLine.EnableDrawing(true);


                Debug.Log("Inside the ball");

 			}
 		}
 		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
 		{
 			drawnLine.EnableDrawing(false);



            //update the velocity of the white ball.
            HVector2D v = new HVector2D(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);

            ball.Velocity = v;

 			drawnLine = null; // End line drawing            
 		}

 		if (drawnLine != null)
 		{
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
