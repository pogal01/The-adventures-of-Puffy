using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAnimationControler : MonoBehaviour
{ 

    private Animator HeadAnim;
    private Animator BodyAnim;
    private GameObject Head;
    private GameObject Body;




    // Start is called before the first frame update
    void Start()
    {
        Head = GameObject.Find("Head");
        Body = GameObject.Find("Body");
        HeadAnim = Head.GetComponent<Animator>();
        BodyAnim = Body.GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            HeadAnim.SetTrigger("Open Mouth");
            BodyAnim.SetTrigger("Open Mouth");




        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            HeadAnim.SetTrigger("Closed Mouth");
            BodyAnim.SetTrigger("Closed Mouth");



        }

       

    }
}
