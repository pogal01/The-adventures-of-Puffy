using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Collision : MonoBehaviour
{
    [SerializeField]
    PolygonCollider2D collision;
    [SerializeField]
    int WhichScene;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Exit confirmed");
            Debug.Log("Heading to Scene" + WhichScene);
            SceneManager.LoadScene(WhichScene);
        }
    }

}
