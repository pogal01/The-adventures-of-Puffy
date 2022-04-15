using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Do_Not_Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] music_Obj = GameObject.FindGameObjectsWithTag("Music");
        if(music_Obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
