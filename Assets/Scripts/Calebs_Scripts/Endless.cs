using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Endless : MonoBehaviour
{
    private float count_Up = 0f;
    private float summon_Timer = 10f;
    private Vector3 position;
    private Quaternion rotation;
    public TMP_Text timer;
    
    public GameObject shark;
    public GameObject shark_Storage;
    public List<GameObject> sharks;
    public int i = 0;

    public GameObject score_Screen;
    public TMP_Text score;
    public TMP_Text time;

    private GameObject puffy;
    CharacterControler cC;

    //public GameObject menu;
    //Menu_Controller mC;

    private void Start()
    {
        score_Screen.SetActive(false);

        puffy = GameObject.Find("Puffy");
        cC = puffy.GetComponent<CharacterControler>();

        //menu = GameObject.Find("Menu_Controller");
        //mC = menu.GetComponent<Menu_Controller>();

        Summon_Shark();
    }

    void Update()
    {
        count_Up += Time.deltaTime;
        summon_Timer -= Time.deltaTime;
        int mins = Mathf.FloorToInt(count_Up / 60F);
        int secs = Mathf.FloorToInt(count_Up - mins * 60);
        int survive_Score = Mathf.FloorToInt(count_Up);
        string timer_Formatting = string.Format("{0:0}:{1:00}", mins, secs);

        timer.text = timer_Formatting;

        //foreach(GameObject shark in sharks)
        //{
        //    Vector3 eulerRotation = transform.rotation.eulerAngles;
        //    transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        //}

        for(i = 0; i < 20; i++)
        {
            if (summon_Timer <= 0)
            {
                Summon_Shark();
                summon_Timer = 10f;
            }
        }

        if (cC.CurrentHealth <= 0)
        {
            Debug.Log("Puffy Died");
            Time.timeScale = 0f;
            score_Screen.SetActive(true);
            time.text = "You survived\n" + timer_Formatting;
            score.text = (survive_Score*2).ToString();
        }
    }

    private void Summon_Shark()
    {
        position = new Vector3(Random.Range(40, -45), Random.Range(40, -45), 0);
        sharks.Add(Instantiate(shark, position, Quaternion.identity, shark_Storage.transform));
        sharks[i].name = "Shark_" + i;
    }
}
