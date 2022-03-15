using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttach : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    private Transform Pos;



    void Start()
    {
        Player = GameObject.Find("Puffy");

        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(Player.transform.position.x,Player.transform.position.y - 0.9f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Player.transform.rotation.z);





    }
}
