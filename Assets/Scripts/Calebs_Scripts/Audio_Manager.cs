using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager AM;

    [SerializeField] private AudioSource music_Source, effect_Scource;

    private void Awake()
    {
        //if (AM == null)
        //{
        //    AM = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

        AudioListener.volume = PlayerPrefs.GetFloat("Game_Volume");
    }

    public void Play_Audio(AudioClip clip)
    {
        effect_Scource.PlayOneShot(clip);
    }
}
