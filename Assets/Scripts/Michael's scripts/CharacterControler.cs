using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControler : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Ridge;
    private bool IsSwimming;
    private float Hoz;
    private float Vert;
    private bool InSky = false;
    private GameObject Player;
    public float TurnSpeed;
    private static Quaternion CurrentRotation;
    private Quaternion NewRotation;
    public bool flipped;
    private PlayerAnimationControler AnimationScript;
    private Expressions ExpressionsScript;
   [HideInInspector] public float DashTimer;
   [HideInInspector] public float DashIntival;
    private bool DashTimerActive;
    private bool IsDashOnCooldown = false;
    private GameObject DashSlider;
    private bool IsDashing;
    private Vector2 Direction;
    public float FlyForce;

    [HideInInspector] public float FlapTimer;
    [HideInInspector] public float FlapIntival;
    private bool FlapTimerActive;
    private bool IsFlapOnCooldown;

    public float BubbleCooldown;
    private float BubbleTime;
    public float GravityRange;

    private int spinCounter;
    private int moveCounter;
    public enum state
    {
        Swim,
        Fly

    }


    private state PuffyState;

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
        ExpressionsScript = Player.GetComponent<Expressions>();

        Ridge = Player.GetComponent<Rigidbody2D>();
        CurrentRotation = Player.transform.rotation;
        IsSwimming = false;
        //Debug.log(Player.transform.rotation);
        Direction = new Vector2(1, 0);
        BubbleCooldown = 0.2f;
        BubbleTime = BubbleCooldown;
        Invoke("StartedInWater", 0.2f);
    }

    void StartedInWater()
    {

        AnimationScript.PlayerAnimator.ResetTrigger("EndFlying");
        ExpressionsScript.ChangeExpression();
    }


    void Dash()
    {
        Ridge.velocity = new Vector3(Hoz,Vert)*Speed*2;
        AnimationScript.DashAnim();
        float DashTime = 0.8f;
        float DashCooldown = 3f;
        IsDashOnCooldown = true;
        DashIntival = DashCooldown;
        DashTimerActive = true;
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

    void Flap()
    {
       
        
        Ridge.velocity = new Vector2 (Ridge.velocity.x, 1)*FlyForce;
        

        AnimationScript.FlapAnim();
        //float FlapCooldown = 0.2f;
        FlapTimer = 0f;
        IsFlapOnCooldown = true;
        FlapIntival = 0.2f;
        FlapTimerActive = true;
        
        


    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        Debug.Log("Puffy has collided with" + Col.gameObject.tag);

        if (Col.tag == "Water")
        {
            PuffyState = state.Swim;
            //Debug.log("State = " + PuffyState);
            Ridge.velocity = new Vector2(0, 0);
            AnimationScript.FlyAnimFin();
            AnimationScript.PlayerAnimator.SetTrigger("SwimStart");
            ExpressionsScript.ChangeExpression();

            Debug.Log("Has entered water");

        }
       
    }

    private void OnTriggerExit2D(Collider2D Col)
	{
        if (Col.tag == "Water" && Ridge.velocity.y > 0)
        {
            PuffyState = state.Fly;
            //Debug.log("State = " + PuffyState);
            AnimationScript.FlyAnimStart();

            Debug.Log("Has left water");
            Ridge.velocity = Ridge.velocity * 1.2f;

            spinCounter = 270;
            InvokeRepeating("SpinToTheRight", 0.05f, 0.005f);
        }
    }
   


    void InvokeFunction(string Function, float TimeToWait)
    {
        Invoke(Function, TimeToWait);




    }


    void MoveUP()
    {
        moveCounter --;
        Ridge.AddForce(new Vector2 (0,1000f));
        if (moveCounter == 0) {
            CancelInvoke("MoveUP");
        }



    }
    void MoveDown()
    {
        moveCounter --;
        Ridge.AddForce(new Vector2 (0,-1000f));
        if (moveCounter == 0) {
            CancelInvoke("MoveDown");
        }

    }


    void StopFLoatAnim()
    {

        Ridge.velocity = new Vector2(0, 0);


    }

    void SpinToTheRight()
    {
        spinCounter --;
        transform.Rotate(0,0,1);
        //Debug.Log("Spin to right");
        Direction = new Vector2(1, 0);
        if (spinCounter == 0) {
            CancelInvoke("SpinToTheRight");
        }

    }


    IEnumerator BubbleBeam()
    {

        if (BubbleTime == BubbleCooldown)
        {
            BubbleTime = 0;

            yield return new WaitForSeconds(BubbleCooldown);
            BubbleTime = BubbleCooldown;


        }
        
       
        
    }



    private void FixedUpdate()
    {
        Hoz = Input.GetAxisRaw("Horizontal");
        Vert = Input.GetAxisRaw("Vertical");

        if (PuffyState == state.Swim) Ridge.gravityScale = 0;
        else Ridge.gravityScale = GravityRange;
        if (PuffyState == state.Swim)
        {
            if (!IsDashing)
            {
                Ridge.velocity = new Vector2(Hoz, Vert) * Speed;



            }

           

            if (Hoz > 0 && Vert == 0) //Right
            {
                NewRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(1, 0);

            }
            if (Vert < 0 && Hoz > 0) //Right and down
            {
                NewRotation = Quaternion.Euler(0, 0, -45);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(1, -1);

            }



            else if (Hoz < 0 && Vert == 0) //Left
            {

                NewRotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(-1, 0);


            }

            else if (Vert < 0 && Hoz < 0) //Down left
            {

                NewRotation = Quaternion.Euler(0, 180, -45);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(-1, -1);


            }


            else if (Vert < 0) // Down
            {
                if (!flipped)
                {
                    NewRotation = Quaternion.Euler(0, 0, -90);
                    transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                    CurrentRotation = Player.transform.rotation;
                    Direction = new Vector2(0, -1);

                }

               

                if (flipped) // Is left
                {
                    NewRotation = Quaternion.Euler(0, 180, -90);
                    transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                    CurrentRotation = Player.transform.rotation;
                    Direction = new Vector2(0, -1);


                }

            }
            else if (Vert > 0 && Hoz > 0) //Up right
            {

                NewRotation = Quaternion.Euler(0, 0, 45);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(1, 1);


            }

            else if (Vert > 0 && Hoz < 0) //Up and Left 
            {

                NewRotation = Quaternion.Euler(0, 180, 45);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(-1, 1);


            }




            else if (Vert > 0) //Up
            {
                if (!flipped)
                {
                    NewRotation = Quaternion.Euler(0, 0, 90);
                    transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                    CurrentRotation = Player.transform.rotation;
                    Direction = new Vector2(0, 1);

                }



                if (flipped) // Is left
                {
                    NewRotation = Quaternion.Euler(0, 180, 90);
                    transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                    CurrentRotation = Player.transform.rotation;
                    Direction = new Vector2(0, 1);


                }

            }





        }
        else if (PuffyState == state.Fly)
        {

            Ridge.velocity = new Vector2(Hoz * Speed, Ridge.velocity.y) ;

            if (Hoz < 0 && Vert == 0) //Left
            {

                NewRotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(-1, 0);


            }
            else if (Hoz > 0 && Vert == 0) //Right
            {
                NewRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = Player.transform.rotation;
                Direction = new Vector2(1, 0);

            }


        }
      




    }

    



    // Update is called once per frame
    void Update()
    {
        if (DashTimerActive)
        {
            DashTimer += Time.deltaTime;

            if (IsDashOnCooldown)
            {
                DashSlider.GetComponent<Slider>().value = DashTimer;


            }
            if(DashTimer >= DashIntival)
            {

                IsDashOnCooldown = false;
                DashTimerActive = false;
                DashTimer = 0;
                DashSlider.SetActive(false);


            }



        }

        if (FlapTimerActive)
        {

            FlapTimer += Time.deltaTime;

            if (FlapTimer >= FlapIntival)
            {
                IsFlapOnCooldown = false;
                FlapTimer = 0;
                Ridge.velocity = new Vector2(Ridge.velocity.x, 0);
                FlapTimerActive = false;

                Debug.Log("Puffy should be flying");

                

            }



        }

        if (Input.GetKeyDown(KeyCode.P))
        {

            //Debug.log(Ridge.velocity);



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



            if (!IsSwimming)
            {
                Ridge.velocity = new Vector2(0, 0);


            }

            if (Hoz == 0 && Vert == 0)
            {
                IsSwimming = false;



            }
            else
            {
                if (!IsDashing)
                {
                    IsSwimming = true;


                }
                else
                {
                    IsSwimming = false;


                }
               

            }




        }
        else if(PuffyState == state.Fly)
        {
            IsSwimming = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Flap();




            }


        }


    }
    
}
