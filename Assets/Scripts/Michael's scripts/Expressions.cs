using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expressions : MonoBehaviour
{
   
     public GameObject [] TheExpressions;
     public GameObject[] TheEyes;
    

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
        Happy,
        Bambozled
    }

    public Faces Expression;
    public Eyes eyes;

    public Faces CurrentFace;
    public Eyes CurrentEyes;

    // Start is called before the first frame update
    void Start()
    {
        eyes = Eyes.Normal;
        Expression = Faces.Normal;
        CurrentFace = Expression;
        CurrentEyes = eyes;
        ActivateEyes(TheEyes[0]);
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

    public void EnableNormalEyes()
    {
        ChangeExpression();




    }

    public void EnableBambozledEyes()
    {
        DisableEyes();
        ActivateEyes(TheEyes[4]);
        ActivateEyes(TheEyes[5]);




    }
    public void ChangeExpression()
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
            case Eyes.Bambozled:
                DisableEyes();
                ActivateEyes(TheEyes[4]);
                ActivateEyes(TheEyes[5]);
                CurrentEyes = eyes;
                Debug.Log("Death eyes");
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

