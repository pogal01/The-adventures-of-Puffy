using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public TMP_Dropdown resolution_Dropdown;

    Resolution[] resolutions;

    [SerializeField] private Slider volume_Slider = null;
    [SerializeField] private TMP_Text volume_Text_UI = null;
    private float volume_Value;

    public bool game_Is_Paused = false;
    public GameObject pause_Menu_UI;
    public GameObject pause_Button_Objects;
    public GameObject settings_Objects;

    public void Start()
    {
        volume_Slider.value = volume_Value;
        AudioListener.volume = volume_Value;
        Get_Resolutions();
        Load_Values();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_Is_Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //----------- GRAPHICS -------------

    public void Set_Quality (int quality_Index)
    {
        QualitySettings.SetQualityLevel(quality_Index);
    }

    //----------- RESOLUTION ----------

    public void Set_Fullscreen (bool is_Fullscreen)
    {
        Screen.fullScreen = is_Fullscreen;
    }

    public void Get_Resolutions()
    {
        resolutions = Screen.resolutions;

        resolution_Dropdown.ClearOptions();

        List<string> options = new List<string>();

        int current_Resolution_Index = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                current_Resolution_Index = i;
            }
        }

        resolution_Dropdown.AddOptions(options);
        resolution_Dropdown.value = current_Resolution_Index;
        resolution_Dropdown.RefreshShownValue();
    }

    public void Set_Resolution (int resolution_Index)
    {
        Resolution resolution = resolutions[resolution_Index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //---------- VOLUME --------------

    public void Volume_Slider(float volume)
    {
        //Debug.Log(volume);
        volume_Text_UI.text = (volume * 100).ToString("0");
    }

    public void Save_Volume_Button()
    {
        volume_Value = volume_Slider.value;
        PlayerPrefs.SetFloat("Game_Volume", volume_Value);
        Load_Values();
    }

    public void Load_Values()
    {
        float volume_Value = PlayerPrefs.GetFloat("Game_Volume");
        volume_Slider.value = volume_Value;
        AudioListener.volume = volume_Value;
    }

    //-------------- PAUSE --------------
    public void Resume()
    {
        Debug.Log("Game Resumed");
        pause_Menu_UI.SetActive(false);
        Time.timeScale = 1f;
        game_Is_Paused = false;
    }

    public void Pause()
    {
        Debug.Log("Game Paused");
        pause_Menu_UI.SetActive(true);
        pause_Button_Objects.SetActive(true);
        settings_Objects.SetActive(false);
        Time.timeScale = 0f;
        game_Is_Paused = true;
    }

    public void Paused_Settings_Open()
    {
        Debug.Log("Paused Settings Opened");
        pause_Button_Objects.SetActive(false);
        settings_Objects.SetActive(true);
    }
    
    public void Paused_Settings_Closed()
    {
        Debug.Log("Paused Settings Closed");
        pause_Button_Objects.SetActive(true);
        settings_Objects.SetActive(false);
    }

    public void Paused_Quit()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Switching to Main Menu");
        SceneManager.LoadScene("Main_Menu_S");
    }
}
