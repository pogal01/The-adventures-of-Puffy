using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 Pos;
    private Vector2 Mousecursor;
<<<<<<< Updated upstream:Assets/Scripts/EyesFollow.cs
    [HideInInspector] public Camera MainCam;
    private GameObject leftEye;
    private GameObject RightEye;
=======
    public Camera PlayerCam;
    public GameObject leftEye;
    public GameObject RightEye;
>>>>>>> Stashed changes:Assets/Scripts/Michael's scripts/EyesFollow.cs
    public Transform LeftClamp;
    public Transform RightClamp;
    public Transform DownClamp;
    public Transform UpClamp;

    void Start()
    {
        PlayerCam = GameObject.Find("Player_Camera").GetComponent<Camera>();
        leftEye = GameObject.Find("Left Pupil Normal");
        RightEye = GameObject.Find("Right Pupil Normal");

        

    }

    // Update is called once per frame
    void Update()
    {

      
        Mousecursor = PlayerCam.ScreenToWorldPoint(Input.mousePosition);
        //float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 90f;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Pos = new Vector2(Mousecursor.x,Mousecursor.y);
        if(gameObject == leftEye)
        {
<<<<<<< Updated upstream:Assets/Scripts/EyesFollow.cs
            Pos.x = Mathf.Clamp(Pos.x, LeftClamp.transform.position.x, RightClamp.transform.position.x);
=======
            Mousecursor = PlayerCam.ScreenToWorldPoint(Input.mousePosition);
            Pos = new Vector2 (Mousecursor.x, Mousecursor.y);
>>>>>>> Stashed changes:Assets/Scripts/Michael's scripts/EyesFollow.cs

            Pos.y = Mathf.Clamp(Pos.y, DownClamp.transform.position.y, UpClamp.transform.position.y);

        }
<<<<<<< Updated upstream:Assets/Scripts/EyesFollow.cs
=======
        else
        {
            Mousecursor = PlayerCam.ScreenToWorldPoint(Input.mousePosition);
            Pos = new Vector2(Mousecursor.x, Mousecursor.y);
>>>>>>> Stashed changes:Assets/Scripts/Michael's scripts/EyesFollow.cs

        if (gameObject == RightEye)
        {
            Pos.x = Mathf.Clamp(Pos.x, -0.95f, -0.8f);

            Pos.y = Mathf.Clamp(Pos.y, 0.4f, 0.6f);

        }



        transform.position = Pos;

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(PlayerCam.ScreenToWorldPoint(Input.mousePosition));

        }
        


        
    }
}
