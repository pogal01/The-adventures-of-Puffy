using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
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

    public void Settings()
    {
        Debug.Log("Switching to Setting");
        SceneManager.LoadScene("Settings_S");
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }


}
