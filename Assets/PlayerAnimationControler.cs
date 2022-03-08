using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControler : MonoBehaviour
{
    private Animator PlayerAnimator;
    private GameObject Player;
    private bool PuffupB = false;
    private Expressions ExpressionsScript;





    // Start is called before the first frame update
    void Start()
    {
        ExpressionsScript = gameObject.GetComponent<Expressions>();

        Player = GameObject.Find("Puffy");
        PlayerAnimator = Player.GetComponent<Animator>();
        

        
    }


    void PuffupAnim()
    {
        PlayerAnimator.SetTrigger("Puffup");
        PuffupB = !PuffupB;
        ExpressionsScript.DisableEyes();
        ExpressionsScript.DisableFace();
        Debug.Log("PuffUp");
        if (!PuffupB)
        {
            ExpressionsScript.Invoke("EnableNormalEyes", 2.7f);
            Debug.Log("Activate eyes");


        }

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
