using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAI : MonoBehaviour
{
    // Start is called before the first frame update
    public int SharkID;
    public GameObject[] Waypoints;
    private int WaypointOrder = 0;
    private Vector3 WhereToGo;
    public float Speed;
    private float AmountOfWaypoints;
    private Rigidbody2D rb;
    private Vector3 Rotation;
    private Transform ThisObject;
    private Transform TheRotation;

    private Vector3 RotationToChangeTo;

    //Raycast
    [SerializeField] private Vector3 RaycastOffset;
    [SerializeField] private Vector3 RaycastOffset2;
    [SerializeField] private float RaycastDistance;
    [SerializeField] private Vector3 RaycastStartPoint;
    //Debug
    private GameObject TargetObject;
   


    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("SharkWaypoint" + SharkID);
        AmountOfWaypoints = Waypoints.Length;
       // Debug.Log("The amount of waypoints for " + SharkID + " Is " + AmountOfWaypoints);
        WhereToGo = Waypoints[WaypointOrder].transform.position;
        rb = GetComponent<Rigidbody2D>();
        ThisObject = gameObject.transform;
        TargetObject = Waypoints[WaypointOrder];
        transform.right = TargetObject.transform.position - transform.position;
        RotationToChangeTo = transform.right = TargetObject.transform.position - transform.position;
        Rotation = transform.rotation.eulerAngles;
        RaycastStartPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        //Debug.Log("Shark has reached "+Collision.name);


        if (Collision.tag == ("SharkWaypoint" + SharkID))
        {
            Debug.Log("Shark has collided with waypoint");
            
            //Rotation = transform.rotation.eulerAngles;
            
            if (WaypointOrder != AmountOfWaypoints-1)
            {
              WaypointOrder = ++WaypointOrder;
                
                WhereToGo = Waypoints[WaypointOrder].transform.position;
                Debug.Log("Waypoint updated");
                TargetObject = Waypoints[WaypointOrder];
                transform.right = TargetObject.transform.position - transform.position;
                RotationToChangeTo = transform.right = TargetObject.transform.position - transform.position;
                Rotation = transform.rotation.eulerAngles;
                CheckSharkIsNotUpsidedown();
            }
            else
            {

                WaypointOrder = 0;
                Debug.Log("Waypoint defaulted back to zero");
                WhereToGo = Waypoints[WaypointOrder].transform.position; // resets the loop
                TargetObject = Waypoints[WaypointOrder];
                transform.right = TargetObject.transform.position - transform.position;
                
                Rotation = transform.rotation.eulerAngles;
                CheckSharkIsNotUpsidedown();

                

            }
            













        }




    }

  

    
        
    void CheckSharkIsNotUpsidedown()
    {
        if(Rotation.z > 90 && Rotation.z < 270)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            
            Debug.Log("The shark is upsidedown");


        }



    }
        

    
    


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Sharks velocity is" + rb.velocity);


        
        float RotationZ = Mathf.Clamp(ThisObject.rotation.z, -270f, -90f);

      
       transform.position = Vector2.MoveTowards(transform.position, WhereToGo, Speed * Time.deltaTime); //Moves the shark
       
        //Raycast stuff
        var Hits2D = Physics2D.RaycastAll(transform.position + RaycastOffset, TargetObject.transform.position, RaycastDistance);
        Debug.DrawLine(transform.position + RaycastOffset2, TargetObject.transform.position + RaycastOffset + new Vector3(0, -RaycastDistance), Color.magenta);
        foreach (var vision in Hits2D)
        {

            if(vision.transform.tag != "Ground")
            {

                if (vision.transform.tag == "Player")
                {
                    Debug.Log("Shark can see puffy");



                }


            }
          





        }




    }

    private void FixedUpdate()
    {
       




    }

}
