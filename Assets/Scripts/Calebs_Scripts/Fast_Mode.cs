using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast_Mode : MonoBehaviour
{
    GameObject other_Puffy;
    GameObject title;
    GameObject audio_Manager;

    public AudioClip Fast_Audio;
    public new AudioSource audio;

    private Animator fast_Mode_L;
    private Animator fast_Mode_R;
    private Animator fast_Mode_T;
    int times_Clicked = 0;

    private void Start()
    {
        other_Puffy = GameObject.Find("Puffy_R");
        title = GameObject.Find("Title");
        audio_Manager = GameObject.Find("Audio_Manager");
        audio = audio_Manager.GetComponentInChildren<AudioSource>();


        fast_Mode_L = this.gameObject.GetComponent<Animator>();
        fast_Mode_R = other_Puffy.gameObject.GetComponent<Animator>();
        fast_Mode_T = title.gameObject.GetComponent<Animator>();

    }


    private void OnMouseDown()
    {
        times_Clicked++;
        Debug.Log("Mouse Clicked");

        if (times_Clicked >= 10)
        {
            fast_Mode_L.SetBool("Fast_Mode", true);
            fast_Mode_R.SetBool("Fast_Mode", true);
            fast_Mode_T.SetBool("Fast_Mode", true);
            audio.clip = Fast_Audio;
            audio.Play();
        }
    }
}
