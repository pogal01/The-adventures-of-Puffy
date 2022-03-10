using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Ridge;
    private bool IsMoveing;
    private float Hoz;
    private float Vert;
    private bool InWater = true;
    private GameObject Player;
    public float TurnSpeed;
    private Quaternion CurrentRotation;
    private Quaternion NewRotation;

    // Start is called before the first frame update
    void Start()
    {
        


        Player = GameObject.Find("Puffy");
        Ridge = Player.GetComponent<Rigidbody2D>();
        CurrentRotation = Player.transform.rotation;
        IsMoveing = false;
        Debug.Log(Player.transform.rotation);

    }



    private void FixedUpdate()
    {
        Hoz = Input.GetAxisRaw("Horizontal");
        Vert = Input.GetAxisRaw("Vertical");

        Ridge.velocity = new Vector2(Hoz, Vert)*Speed;

        if(Hoz > 0)
        {
            NewRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
            CurrentRotation = Player.transform.rotation;


        }
        else if(Hoz < 0)
        {
            
            NewRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
            CurrentRotation = Player.transform.rotation;



        }
        else if(Vert < 0)
        {
            NewRotation = Quaternion.Euler(0, transform.rotation.y, 270);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
            CurrentRotation = Player.transform.rotation;




        }
        else if (Vert > 0)
        {
            NewRotation = Quaternion.Euler(0, transform.rotation.y, 90);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
            CurrentRotation = Player.transform.rotation;




        }




    }

    



    // Update is called once per frame
    void Update()
    {
        if (!IsMoveing)
        {
            Ridge.velocity = new Vector2(0, 0);


        }

        if(Hoz == 0 && Vert == 0)
        {
            IsMoveing = false;



        }
        else
        {
            IsMoveing = true;

        }











    }
}
