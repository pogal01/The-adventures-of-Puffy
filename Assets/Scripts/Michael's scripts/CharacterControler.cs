using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool flipped;
    private PlayerAnimationControler AnimationScript;
    public float Timer;
    public float Intival;
    private bool TimerActive;
    private bool IsDashOnCooldown = false;
    private GameObject DashSlider;
    private bool IsDashing;
    private Vector2 Direction;






    public enum state
    {
        Swim,
        Fly

    }


    public state PuffyState;

    private void Awake()
    {
        DashSlider = GameObject.Find("DashCooldown");
    }


    // Start is called before the first frame update
    void Start()
    {
        PuffyState = state.Swim;
        Player = GameObject.Find("Puffy");
        AnimationScript = Player.GetComponent<PlayerAnimationControler>();
        

        Ridge = Player.GetComponent<Rigidbody2D>();
        CurrentRotation = Player.transform.rotation;
        IsMoveing = false;
        Debug.Log(Player.transform.rotation);
        Direction = new Vector2(1, 0);
    }

    void Dash()
    {
        Ridge.velocity = new Vector3(Hoz,Vert)*Speed*2;
        AnimationScript.DashAnim();
        float DashTime = 0.8f;
        float DashCooldown = 3f;
        IsDashOnCooldown = true;
        Intival = DashCooldown;
        TimerActive = true;
        IsDashing = true;
        Speed = 0;
        Invoke("FinshDash", 0.7f);
    }

    void FinshDash()
    {
        float DashForce = 10000f;

        Ridge.AddForce((Direction)*DashForce);

        Speed = 10f;
        IsDashing = false;

    }



    private void FixedUpdate()
    {
        Hoz = Input.GetAxisRaw("Horizontal");
        Vert = Input.GetAxisRaw("Vertical");
        if (PuffyState == state.Swim)
        {
            if (!IsDashing)
            {
                Ridge.velocity = new Vector2(Hoz, Vert) * Speed;



            }

           

            if (Hoz > 0)
            {
                NewRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(1, 0);

            }
            else if (Hoz < 0)
            {

                NewRotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(-1, 0);


            }
            else if (Vert < 0)
            {
                NewRotation = Quaternion.Euler(0, transform.rotation.y, 270);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(0, -1);



            }
            else if (Vert > 0)
            {
                NewRotation = Quaternion.Euler(0, transform.rotation.y, 90);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(0, 1);



            }





        }
      




    }

    



    // Update is called once per frame
    void Update()
    {
        if (TimerActive)
        {
            Timer += Time.deltaTime;

            if (IsDashOnCooldown)
            {
                DashSlider.GetComponent<Slider>().value = Timer;


            }

            if (Timer >= Intival)
            {
                IsDashOnCooldown = false;
                TimerActive = false;
                Timer = 0;
                DashSlider.SetActive(false);
               


            }


        }
     

       



        if (Input.GetKeyDown(KeyCode.R))
        {

            if (!IsDashOnCooldown)
            {
                Dash();
                


            }



        }

        


        if(CurrentRotation.y < -0.7)
        {
            flipped = true;



        }
        else
        {
            flipped = false;


        }



        if(CurrentRotation == Quaternion.Euler(0,180, 0))
        {





        }

        if(PuffyState == state.Swim)
        {



            if (!IsMoveing)
            {
                Ridge.velocity = new Vector2(0, 0);


            }

            if (Hoz == 0 && Vert == 0)
            {
                IsMoveing = false;



            }
            else
            {
                IsMoveing = true;

            }




        }
      


    }
}
