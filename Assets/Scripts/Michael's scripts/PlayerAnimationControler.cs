using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControler : MonoBehaviour
{
   [HideInInspector] public Animator PlayerAnimator;
    private GameObject Player;
    private bool PuffupB = false;
    private Expressions ExpressionsScript;
	private CharacterControler CharScript;


    //Collision boxes for Puffy
    private GameObject StartPuffCol;
    private GameObject AlmostPuffedCol;
    private GameObject PuffedPuCol;
	private GameObject NormalCollider;

	private GameObject DashCol1;
	private GameObject DashCol2;

	private GameObject HopCollider;
	

	// Start is called before the first frame update

	private GameObject DashSlider;


    void Start()
    {
		

        ExpressionsScript = gameObject.GetComponent<Expressions>();
		CharScript = gameObject.GetComponent<CharacterControler>();
		DashSlider = GameObject.Find("DashCooldown");
        Player = GameObject.Find("Puffy");
        PlayerAnimator = Player.GetComponent<Animator>();
		HopCollider = GameObject.Find("HopCollider");

		DashSlider.SetActive(false);
        //Colliders
        StartPuffCol = GameObject.Find("StartPuffCol");
        AlmostPuffedCol = GameObject.Find("AlmostPuffedCol");
        PuffedPuCol = GameObject.Find("PuffedupCol");

        DashCol1 = GameObject.Find("DashColPt1");
		DashCol2 = GameObject.Find("DashCol");

		


		StartPuffCol.GetComponent<PolygonCollider2D>().enabled = false;
        AlmostPuffedCol.GetComponent<PolygonCollider2D>().enabled = false;
        PuffedPuCol.GetComponent<PolygonCollider2D>().enabled = false;
		NormalCollider = GameObject.Find("MainCollisionCopy");
		NotGrounded();
		//



	}


    void PuffupAnim()
    {
        PlayerAnimator.SetTrigger("Puffup");
        PuffupB = !PuffupB;
        ExpressionsScript.DisableEyes();
        ExpressionsScript.DisableFace();
        if (PuffupB)
        {
            StartCoroutine(CheekyWorkaround("ChangeCollision", 1.5f, StartPuffCol.GetComponent<PolygonCollider2D>()));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 2f, AlmostPuffedCol.GetComponent<PolygonCollider2D>()));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 2.9f, PuffedPuCol.GetComponent<PolygonCollider2D>()));
        }
        
        Debug.Log("PuffUp");
        if (!PuffupB)
        {
            StartCoroutine(CheekyWorkaround("ChangeCollision", 1f, AlmostPuffedCol.GetComponent<PolygonCollider2D>()));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 1.5f, StartPuffCol.GetComponent<PolygonCollider2D>()));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 2f,NormalCollider.GetComponent<PolygonCollider2D>()));
			ExpressionsScript.Invoke("EnableNormalEyes", 2.7f);
			Player.GetComponent<PolygonCollider2D>().enabled = true;
            Debug.Log("Activate eyes");


        }

    }


    public void ChangeCollision(PolygonCollider2D Col)
    {

        Player.GetComponent<PolygonCollider2D>().points = Col.points;
        Player.GetComponent<PolygonCollider2D>().enabled = true;

        Debug.Log("Collision enabled for " + Col.name);

    }

    IEnumerator CheekyWorkaround(string FunctName,float Time, PolygonCollider2D Obj)
    {
        
        


        yield return new WaitForSeconds(Time);
        
        if(FunctName == "ChangeCollision")
        {
            ChangeCollision(Obj);
            Debug.Log(FunctName + "Took" + Time + " Seconds" + " Enabled collision for " + Obj.name);



        }


        /*
        if (Timer >= EndTime)
        {



            StartTimer = false;
            Timer = 0;
        }
        */

    }

	public void StartSwim()
	{
		PlayerAnimator.SetTrigger("SwimStart");



	}


   public void FlyAnimStart()
   {
        PlayerAnimator.SetTrigger("StartFlying");
        ChangeCollision(NormalCollider.GetComponent<PolygonCollider2D>());
   }

   public void FlyAnimFin()
   {
       PlayerAnimator.SetTrigger("EndFlying");
        
    }

  public void FlapAnim()
  {
        PlayerAnimator.SetTrigger("Flap");
        

        
  }



    public void DashAnim()
    {
        PlayerAnimator.SetTrigger("ActivatedDash");
        DashSlider.SetActive(true);
		StartCoroutine(CheekyWorkaround("ChangeCollision", 0.2f, DashCol1.GetComponent<PolygonCollider2D>()));
		StartCoroutine(CheekyWorkaround("ChangeCollision", 0.6f, DashCol2.GetComponent<PolygonCollider2D>()));
		StartCoroutine(CheekyWorkaround("ChangeCollision", 1.2f, NormalCollider.GetComponent<PolygonCollider2D>()));
	}

    
	public void ISGrounded()
	{
		PlayerAnimator.SetBool("Grounded", true);
		ChangeCollision(HopCollider.GetComponent<PolygonCollider2D>());


	}

	public void NotGrounded()
	{
		PlayerAnimator.SetBool("Grounded", false);
		ChangeCollision(NormalCollider.GetComponent<PolygonCollider2D>());


	}


	// Update is called once per frame
	void Update()
    {
		if(CharScript.swimming == true)
		{

			if (Input.GetKeyDown(KeyCode.F))
			{
				PuffupAnim();


			}



		}
    

        if (PuffupB)
        {
            PlayerAnimator.SetBool("PuffedUpB", true); 
            

        }
        else
        {
            PlayerAnimator.SetBool("PuffedUpB", false);
            

        }


        

    }

    
    


}
