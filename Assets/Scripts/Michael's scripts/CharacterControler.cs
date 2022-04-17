using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControler : MonoBehaviour
{
    public float Speed;
    public float maxSpeed = 10;
    private bool jumped = false;
    private Rigidbody2D Ridge;
    private bool IsSwimming;
    private float Hoz;
    private float Vert;
    private bool InSky = false;
    private GameObject Player;
    public float TurnSpeed;
    private Quaternion CurrentRotation;
    private Quaternion NewRotation;

    private static Vector3 startRotation;
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
    public bool swimming = true;


    private void Awake()
    {
        DashSlider = GameObject.Find("DashCooldown");
    }

	//Grounded stuff
	private bool Grounded;
	

	//Debug
	public Collider2D LastCollider;

	// Start is called before the first frame update
	void Start()
    {
        //swimming = true;
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
       
        
        //Ridge.velocity = new Vector2 (Ridge.velocity.x, 1)*FlyForce;
        

        AnimationScript.FlapAnim();
        //float FlapCooldown = 0.2f;
        FlapTimer = 0f;
        IsFlapOnCooldown = true;
        FlapIntival = 0.2f;
        FlapTimerActive = true;
        
        


    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        //Debug.Log("Puffy has collided with" + Col.gameObject.tag);
		LastCollider = Col;
        if (Col.tag == "Water")
        {
            Debug.Log("in water!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            swimming = true;
            AnimationScript.PlayerAnimator.SetBool("IsInAir", false);
            Ridge.gravityScale = 0;

            AnimationScript.FlyAnimFin();
            AnimationScript.PlayerAnimator.ResetTrigger("StartFlying");
            AnimationScript.PlayerAnimator.SetTrigger("SwimStart");
            ExpressionsScript.ChangeExpression();

        }
		/*
		if (Col.tag == "Water" && Vert <= 0  )
		{
			Splash();

		}
		*/

	}

    private void OnTriggerExit2D(Collider2D Col)
	{
		LastCollider = Col;
		if (Col.tag == "Water" && Ridge.velocity.y > 0)
        {
            Debug.Log("left water!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            swimming = false;
            AnimationScript.PlayerAnimator.SetBool("IsInAir", true);
            Ridge.gravityScale = GravityRange;
            Ridge.velocity = new Vector2(Ridge.velocity.x, Ridge.velocity.y * 1.2f);

            AnimationScript.FlyAnimStart();
            AnimationScript.PlayerAnimator.ResetTrigger("SwimStart");
			AnimationScript.PlayerAnimator.ResetTrigger("EndFlying");
        }
    }

	/*
	void Splash()
	{
		MoveDown();
		Debug.Log("Splash");



	}
	*/

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Ground")
		{
			Grounded = true;
			AnimationScript.ISGrounded();


		}




	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.tag == "Ground")
		{
			Grounded = false;
			AnimationScript.NotGrounded();


		}
	}

   


    void InvokeFunction(string Function, float TimeToWait)
    {
        Invoke(Function, TimeToWait);
		



    }


    void MoveUP()
    {
        moveCounter --;
        Ridge.AddForce(new Vector2 (0,800f));
		
		if (moveCounter == 0) {
            CancelInvoke("MoveUP");
        }
		Debug.Log("MoveUP");


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

    IEnumerator SpinToTheRight()
    {
        for (float t = 0; t <= 0.5; t += Time.deltaTime) {
            yield return null;
        }
        startRotation = transform.eulerAngles;
        //Debug.Log(startRotation.z);
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {   
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, Mathf.Lerp(startRotation.z, 720, t));
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        Direction = new Vector2(1, 0);
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
        float Hoz = Input.GetAxisRaw("Horizontal");
        float Vert = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");
        if(Ridge.gravityScale == GravityRange) swimming = false;

        if(swimming) {
            Ridge.velocity += new Vector2(Hoz, Vert) * Speed;
            if(Ridge.velocity.magnitude > maxSpeed) Ridge.velocity = Vector3.Normalize(Ridge.velocity) * maxSpeed;
            if(Hoz == 0 && Vert == 0) Ridge.velocity = Vector2.zero;
        }
        else {
            Ridge.velocity = new Vector2(Hoz * maxSpeed, Ridge.velocity.y);
            if(jump > 0 && !jumped) {
                Flap();
                Ridge.velocity = new Vector2(Ridge.velocity.x, FlyForce);
                jumped = true;
            }
            else if(jump == 0) jumped = false;
        }

        CurrentRotation = transform.rotation;

        if (Hoz > 0 && Vert == 0) //Right
        {
            NewRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
            CurrentRotation = transform.rotation;
            Direction = new Vector2(1, 0);

        }
        if (Vert < 0 && Hoz > 0) //Right and down
        {
            NewRotation = Quaternion.Euler(0, 0, -45);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
            CurrentRotation = transform.rotation;
            Direction = new Vector2(1, -1);

        }



        else if (Hoz < 0 && Vert == 0) //Left
        {

            NewRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
            CurrentRotation = transform.rotation;
            Direction = new Vector2(-1, 0);


        }

        else if (Vert < 0 && Hoz < 0) //Down left
        {

            NewRotation = Quaternion.Euler(0, 180, -45);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
            CurrentRotation = transform.rotation;
            Direction = new Vector2(-1, -1);


        }


        else if (Vert < 0) // Down
        {
            if (!flipped)
            {
                NewRotation = Quaternion.Euler(0, 0, -90);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = transform.rotation;
                Direction = new Vector2(0, -1);

            }

            

            if (flipped) // Is left
            {
                NewRotation = Quaternion.Euler(0, 180, -90);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = transform.rotation;
                Direction = new Vector2(0, -1);


            }

        }
        else if (Vert > 0 && Hoz > 0) //Up right
        {

            NewRotation = Quaternion.Euler(0, 0, 45);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
            CurrentRotation = transform.rotation;
            Direction = new Vector2(1, 1);


        }

        else if (Vert > 0 && Hoz < 0) //Up and Left 
        {

            NewRotation = Quaternion.Euler(0, 180, 45);
            transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed); //Flipped
            CurrentRotation = transform.rotation;
            Direction = new Vector2(-1, 1);

        }

        else if (Vert > 0) //Up
        {
            if (!flipped)
            {
                NewRotation = Quaternion.Euler(0, 0, 90);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = transform.rotation;
                Direction = new Vector2(0, 1);

            }



            if (flipped) // Is left
            {
                NewRotation = Quaternion.Euler(0, 180, 90);
                transform.rotation = Quaternion.Slerp(CurrentRotation, NewRotation, TurnSpeed);
                CurrentRotation = transform.rotation;
            }
        }
    }

    



    // Update is called once per frame
    void Update()
    {

		if(Hoz != 0)
		{
			AnimationScript.PlayerAnimator.SetBool("IsMoving", true);




		}
		else
		{
			AnimationScript.PlayerAnimator.SetBool("IsMoving", false);

		}



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
                //Ridge.velocity = new Vector2(Ridge.velocity.x, 0);
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

        if(swimming)
        {

			//GravityRange = 0;

            if (!IsSwimming)
            {
                //Ridge.velocity = new Vector2(0, 0);


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


    }
    
}
