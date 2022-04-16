using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    GameObject Button;

    public int sceneNumber;
    public static int previousScene;
    public int oldPreviousScene;

    public void Start()
    {
        oldPreviousScene = previousScene;
        previousScene = SceneManager.GetActiveScene().buildIndex;

        //Button = GameObject.FindGameObjectWithTag("Credits Back");
    }

    public void Tutorial()
    {
        Debug.Log("Switching to Tutorial");
        SceneManager.LoadScene("Tutorial_S");
    }
    
    public void Water_Level()
    {
        Debug.Log("Switching to Underwater Level");
        SceneManager.LoadScene("Water_Level_S");
    }
    
    public void Land_Level()
    {
        Debug.Log("Switching to Land Level");
        SceneManager.LoadScene("Land_Level_S");
    }
    
    public void Final_Level()
    {
        Debug.Log("Switching to Final Level");
        SceneManager.LoadScene("Final_Level_S");
    }

    public void Main_Menu()
    {
        Debug.Log("Switching to Main Menu");
        SceneManager.LoadScene("Main_Menu_S");
    }

    public void Settings()
    {
        if (oldPreviousScene == 0)
        {
            Debug.Log("Switching to Setting");
            SceneManager.LoadScene("Settings_S");
        }
        else if (oldPreviousScene == 1)
        {
            Debug.Log("Switching to Setting");
            SceneManager.LoadScene("Settings_S");
        }
        else if (oldPreviousScene == 6)
        {
            Debug.Log("Switching to Main Menu");
            SceneManager.LoadScene("Main_Menu_S");
        }
    }

    public void Credits()
    {
        Debug.Log("Switching to Credits");
        SceneManager.LoadScene("Credits_S");
        
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    
}
