using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private GameObject Player;
    private Camera MainCam;
    private GameObject MainCamOBJ;
    private float DistanceFromPlayer;
    private Vector3 Dist;



    // Start is called before the first frame update
    void Start()
    {
        DistanceFromPlayer = -5f;
        Player = GameObject.Find("Puffy");
        MainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        MainCamOBJ = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Dist = new Vector3(0, 0, DistanceFromPlayer);
        MainCamOBJ.transform.position = Player.transform.position + Dist;
    }
}
