using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expressions : MonoBehaviour
{
   
    [HideInInspector]  public GameObject [] TheExpressions;
    [HideInInspector]  public GameObject[] TheEyes;
   

    public enum Faces
    {
        Happy,
        Sad,
        Open,
        Normal,
        Closed
    }
    public enum Eyes
    {
        Normal,
        Happy
    }

    public Faces Expression;
    public Eyes eyes;

    private Faces CurrentFace;
    private Eyes CurrentEyes;

    // Start is called before the first frame update
    void Start()
    {
        eyes = Eyes.Normal;
        Expression = Faces.Normal;
        CurrentFace = Expression;
        CurrentEyes = eyes;
        ChangeExpression();
    }

    // Update is called once per frame

   public void ActivateFace(GameObject Face)
    {
        DisableFace();
        Face.SetActive(true);


    }

    public void ActivateEyes(GameObject eyes)
    {
        
        eyes.SetActive(true);


    }

    public void DisableEyes()
    {
        foreach (var Eyes in TheEyes)
        {
            Eyes.SetActive(false);


        }
    }

    public void DisableFace()
    {
        foreach (var Mouth in TheExpressions)
        {
            Mouth.SetActive(false);


        }
    }


    private void ChangeExpression()
    {
        switch (Expression)
        {
            case Faces.Happy:
                ActivateFace(TheExpressions[1]);
                CurrentFace = Expression;

                break;
            case Faces.Sad:
                ActivateFace(TheExpressions[3]);
                CurrentFace = Expression;
                break;
            case Faces.Open:
                ActivateFace(TheExpressions[4]);
                CurrentFace = Expression;
                break;
            case Faces.Normal:
                ActivateFace(TheExpressions[2]);
                CurrentFace = Expression;
                break;
            case Faces.Closed:
                ActivateFace(TheExpressions[0]);
                CurrentFace = Expression;
                break;
            default:
                break;
        }

        switch (eyes)
        {
            case Eyes.Normal:
                DisableEyes();
                ActivateEyes(TheEyes[0]);
                ActivateEyes(TheEyes[1]);
                CurrentEyes = eyes;
                Debug.Log("Normal Eyes");
                break;
            case Eyes.Happy:
                DisableEyes();
                ActivateEyes(TheEyes[2]);
                ActivateEyes(TheEyes[3]);
                CurrentEyes = eyes;
                Debug.Log("Happy Eyes");
                break;
            default:
                break;

        }
    }



    void Update()
    {
        

        if (CurrentFace != Expression || CurrentEyes != eyes)
        {
            ChangeExpression();


        }



    }

         


}

