using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_Controller : MonoBehaviour
{
    [SerializeField] private Slider volume_Slider = null;
    [SerializeField] private TMP_Text volume_Text_UI = null;

    public TMP_Dropdown resolution_Dropdown;

    Resolution[] resolutions;

    public void Start()
    {
        Load_Values();
        Get_Resolutions();
    }

    //---------- VOLUME --------------

    public void Volume_Slider(float volume)
    {
        Debug.Log(volume);
        volume_Text_UI.text = (volume*100).ToString("0");
    }

    public void Save_Volume_Button()
    {
        float volume_Value = volume_Slider.value;
        PlayerPrefs.SetFloat("Game_Volume", volume_Value);
        Load_Values();
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

    void Load_Values()
    {
        float volume_Value = PlayerPrefs.GetFloat("Game_Volume");
        volume_Slider.value = volume_Value;
        AudioListener.volume = volume_Value;
    }

}
