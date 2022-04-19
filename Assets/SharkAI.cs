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
    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("SharkWaypoint" + SharkID);
        AmountOfWaypoints = Waypoints.Length;
       // Debug.Log("The amount of waypoints for " + SharkID + " Is " + AmountOfWaypoints);
        WhereToGo = Waypoints[WaypointOrder].transform.position;
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        //Debug.Log("Shark has reached "+Collision.name);


        if (Collision.tag == ("SharkWaypoint" + SharkID))
        {
            Debug.Log("Shark has collided with waypoint");


           
            if (WaypointOrder != AmountOfWaypoints)
            {
              WaypointOrder = ++WaypointOrder;
                
                WhereToGo = Waypoints[WaypointOrder].transform.position;
                Debug.Log("Waypoint updated");


            }
            else
            {

                WaypointOrder = 0;
                Debug.Log("Waypoint defaulted back to zero");
                WhereToGo = Waypoints[WaypointOrder].transform.position; // resets the loop


            }














        }




    }

    
        

        


    


    // Update is called once per frame
    void Update()
    {
        Rotation = transform.rotation.eulerAngles;

        if(Rotation.z > 90 && Rotation.z < 180)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);





        }

        /*
        if (WaypointOrder == AmountOfWaypoints)
        {
           

        }
        */

        transform.position = Vector2.MoveTowards(transform.position, WhereToGo, Speed * Time.deltaTime); //Moves
        transform.right = WhereToGo - transform.position; //rotates

        /*
        if(transform.rotation.eulerAngles.z > 90)
        {
            transform.rotation = Quaternion.Euler(180, transform.rotation.y, transform.rotation.z);



        }
        */

    }

    private void FixedUpdate()
    {
       




    }

}
