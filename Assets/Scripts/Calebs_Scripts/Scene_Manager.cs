using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager SM;

    public GameObject Loading_Panel;
    public Slider slider;
    public TMP_Text progress_Text;

    public int sceneNumber;
    public static int previousScene;
    public int oldPreviousScene;

    public void Load_Level(int scene_Index)
    {
        StartCoroutine(Load_Asynchronously(scene_Index));
    }

    public IEnumerator Load_Asynchronously(int scene_Index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene_Index);

        Loading_Panel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            Debug.Log(progress);

            slider.value = progress;
            progress_Text.text = progress * 100f + "%";

            yield return null;
        }

        while (operation.isDone)
        {
            Time.timeScale = 1.0f;
            Loading_Panel.SetActive(false);
        }
    }

    public void Start()
    {
        Time.timeScale = 1.0f;
        oldPreviousScene = previousScene;
        previousScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void Main_Menu()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Switching to Main Menu");
        SceneManager.LoadScene("Main_Menu_S");
    }

    public void Gamemodes()
    {
        Debug.Log("Switching to Gamemodes");
        SceneManager.LoadScene("Gamemodes_S");
    }

    public void Settings()
    {
        if (oldPreviousScene == 0)
        {
            Debug.Log("Switching to Setting");
            SceneManager.LoadScene("Settings_S");
        }
        else if (oldPreviousScene == 7)
        {
            Debug.Log("Switching to Main Menu");
            SceneManager.LoadScene("Main_Menu_S");
        }
        else
        {
            Debug.Log("Switching to Setting");
            SceneManager.LoadScene("Settings_S");
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
