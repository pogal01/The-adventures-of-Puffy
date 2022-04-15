using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Audio_On_Start : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        Audio_Manager.AM.Play_Audio(clip);
    }

}
