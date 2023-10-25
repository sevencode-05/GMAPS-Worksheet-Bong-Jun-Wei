using Unity.VisualScripting;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -minX;
        minY = -minY;
    }

    void Question2a()
    {
        //setting the starting point to the cooridnates of (x,y) = (0,0)
        startPt = new Vector2(0, 0);
        //setting the end point to the coordinates (x,y) = (2,3)
        endPt = new Vector2(2, 3);

        //
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;

        Debug.Log("Magnitude = " + vec2.magnitude);

    }

    void Question2b(int n)
    {
        CalculateGameDimensions();

        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2 (Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

            drawnLine.EnableDrawing(true);

            
            Debug.Log("Looped for " + i);
            Debug.Log("Start Point is " + startPt);
            Debug.Log("End Point is " + endPt);
            
        }

    }

    void Question2d()
    {
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), new Vector3(5, 5, 0), Color.red, 60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            

            
            CalculateGameDimensions ();

            DebugExtension.DebugArrow(new Vector3(0,0,0), new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-maxY, maxY)), Color.red, 60f);

            // Your code here
            // ...

            //DebugExtension.DebugArrow(
            //    new Vector3(0, 0, 0),
            //    // Your code here,
            //    Color.white,
            //    60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b ;

        

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));
        // Your code here
        // ...

        // Your code here

        //Debug.Log("Magnitude of a = " + // Your code here.ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a / 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1,0,0), b.ToUnityVector3(), Color.green, 60f);



        // Your code here
        // ...

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D normalizedA = new HVector2D(a.x, a.y);
        normalizedA.Normalize();

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3 (1,0,0), normalizedA.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of normalized a = " + normalizedA.Magnitude().ToString("F2"));

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        int x = 0;

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

       //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
       //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
       //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
