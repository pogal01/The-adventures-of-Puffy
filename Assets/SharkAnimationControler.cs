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

    public void OpenMouth()
    {
        HeadAnim.SetTrigger("Open Mouth");
        BodyAnim.SetTrigger("Open Mouth");

    }

    public void CloseMouth()
    {

        HeadAnim.SetTrigger("Close Mouth");
        BodyAnim.SetTrigger("Close Mouth");


    }

    // Update is called once per frame
    void Update()
    {
 

       

    }
}
