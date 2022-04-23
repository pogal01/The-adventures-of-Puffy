using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Credits_Scroll : MonoBehaviour
{
    // The arrays of elements to scroll
    public TMP_Text[] text_Elements;
    public GameObject[] object_Elements;

    // The delay time before starting the GUIText scroll
    public float delay_Time = 5.0f;
    public float scroll_Speed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        delay_Time -= Time.deltaTime;

        if (delay_Time < 0 && text_Elements[0].transform.localPosition.y <= 4600)
        {
            foreach (TMP_Text Text in text_Elements)
            {
                Text.transform.Translate(Vector3.up * (scroll_Speed * Time.deltaTime));
            }
            foreach (GameObject Object in object_Elements)
            {
                if (Object != object_Elements[0])
                {
                    Object.transform.Translate(Vector3.up * (scroll_Speed * Time.deltaTime));
                }   
            }
        }

        if (text_Elements[0].transform.localPosition.y >= -235 && text_Elements[0].transform.localPosition.y <= 4600)
        {
            object_Elements[0].transform.Translate(Vector3.up * (scroll_Speed * Time.deltaTime));
        }
    }
}

