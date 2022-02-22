using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expressions : MonoBehaviour
{
   
    [HideInInspector]  public GameObject [] TheExpressions;


    public enum Faces
    {
        Happy,
        Sad,
        Open,
        Normal,
        Closed
    }
    public Faces Expression;


    // Start is called before the first frame update
    void Start()
    {
        Expression = Faces.Normal;
    }

    // Update is called once per frame

   public void ActivateFace(GameObject Face)
    {
        DisableFace();
        Face.SetActive(true);


    }

    public void DisableFace()
    {
        foreach (var Mouth in TheExpressions)
        {
            Mouth.SetActive(false);


        }
    }



    void Update()
    {
        switch (Expression)
        {
            case Faces.Happy:
                ActivateFace(TheExpressions[1]);
             
                break;
            case Faces.Sad:
               ActivateFace(TheExpressions[3]);
               
                break;
            case Faces.Open:
                ActivateFace(TheExpressions[4]);
              
                break;
            case Faces.Normal:
                ActivateFace(TheExpressions[2]);
               
                break;
            case Faces.Closed:
                ActivateFace(TheExpressions[0]);
              
                break;
            default:
                break;
        }
    }
}
