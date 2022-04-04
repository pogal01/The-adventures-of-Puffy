using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private GameObject Player;
    private Camera PlayerCam;
    private GameObject MainCamOBJ;
    private float DistanceFromPlayer;
    private Vector3 Dist;



    // Start is called before the first frame update
    void Start()
    {
        DistanceFromPlayer = -5f;
        Player = GameObject.Find("Puffy");
        PlayerCam = GameObject.Find("Player_Camera").GetComponent<Camera>();
        MainCamOBJ = GameObject.Find("Player_Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Dist = new Vector3(0, 0, DistanceFromPlayer);
        MainCamOBJ.transform.position = Player.transform.position + Dist;
    }
}
