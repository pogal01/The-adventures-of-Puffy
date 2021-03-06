using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    public Vector2 Pos;
    private Vector2 Mousecursor;
    public Camera PlayerCam;
    public GameObject leftEye;
    public GameObject RightEye;
    public Transform LeftClamp;
    public Transform RightClamp;
    public Transform DownClamp;
    public Transform UpClamp;
    private CharacterControler PuffyControlerscript;
    void Start()
    {
        PlayerCam = GameObject.Find("Player_Camera").GetComponent<Camera>();
        leftEye = GameObject.Find("Left Pupil Normal");
        RightEye = GameObject.Find("Right Pupil Normal");
        Player = GameObject.Find("Puffy");
        PuffyControlerscript = Player.GetComponent<CharacterControler>();
        

    }

    // Update is called once per frame
    void Update()
    {

      
        Mousecursor = PlayerCam.ScreenToWorldPoint(Input.mousePosition);
        //float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 90f;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        

        if (PuffyControlerscript.flipped)
        {
            Mousecursor = PlayerCam.ScreenToWorldPoint(Input.mousePosition);
            Pos = new Vector2 (Mousecursor.x, Mousecursor.y);

            Pos.x = Mathf.Clamp(Pos.x, RightClamp.transform.position.x, LeftClamp.transform.position.x);
            Pos.y = Mathf.Clamp(Pos.y, DownClamp.transform.position.y, UpClamp.transform.position.y);

        }
        else
        {
            Mousecursor = PlayerCam.ScreenToWorldPoint(Input.mousePosition);
            Pos = new Vector2(Mousecursor.x, Mousecursor.y);

            Pos.x = Mathf.Clamp(Pos.x, LeftClamp.transform.position.x, RightClamp.transform.position.x);
            Pos.y = Mathf.Clamp(Pos.y, DownClamp.transform.position.y, UpClamp.transform.position.y);
        }
        


      



        transform.position = Pos;

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(PlayerCam.ScreenToWorldPoint(Input.mousePosition));

        }
        


        
    }
}
