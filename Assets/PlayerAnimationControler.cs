using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControler : MonoBehaviour
{
    private Animator PlayerAnimator;
    private GameObject Player;
    private bool PuffupB = false;
    private Expressions ExpressionsScript;

    //Collision boxes for Puffy
    private GameObject StartPuffCol;
    private GameObject AlmostPuffedCol;
    private GameObject PuffedPuCol;




    // Start is called before the first frame update
    void Start()
    {
        ExpressionsScript = gameObject.GetComponent<Expressions>();

        Player = GameObject.Find("Puffy");
        PlayerAnimator = Player.GetComponent<Animator>();

        //Colliders
        StartPuffCol = GameObject.Find("StartPuffCol");
        AlmostPuffedCol = GameObject.Find("AlmostPuffedCol");
        PuffedPuCol = GameObject.Find("PuffedupCol");
        StartPuffCol.GetComponent<PolygonCollider2D>().enabled = false;
        AlmostPuffedCol.GetComponent<PolygonCollider2D>().enabled = false;
        PuffedPuCol.GetComponent<PolygonCollider2D>().enabled = false;


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
            StartCoroutine(CheekyWorkaround("ChangeCollision", 1.5f, StartPuffCol));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 2f, AlmostPuffedCol));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 2.9f, PuffedPuCol));
        }
        
        Debug.Log("PuffUp");
        if (!PuffupB)
        {
            ExpressionsScript.Invoke("EnableNormalEyes", 2.7f);
            StartCoroutine(CheekyWorkaround("ChangeCollision", 1f, AlmostPuffedCol));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 1.5f, StartPuffCol));
            StartCoroutine(CheekyWorkaround("ChangeCollision", 2f, Player));
            Player.GetComponent<PolygonCollider2D>().enabled = true;
            Debug.Log("Activate eyes");


        }

    }

    void ChangeCollision(GameObject Col)
    {
        Player.GetComponent<PolygonCollider2D>().enabled = false;
        StartPuffCol.GetComponent<PolygonCollider2D>().enabled = false;
        AlmostPuffedCol.GetComponent<PolygonCollider2D>().enabled = false;
        PuffedPuCol.GetComponent<PolygonCollider2D>().enabled = false;
        Col.GetComponent<PolygonCollider2D>().enabled = true;

        Debug.Log("Collision enabled for " + Col.name);

    }

    IEnumerator CheekyWorkaround(string FunctName,float Time,GameObject Obj)
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


    void FlyAnim()
    {



    }

    void DashAnim()
    {



    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PuffupAnim();


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
