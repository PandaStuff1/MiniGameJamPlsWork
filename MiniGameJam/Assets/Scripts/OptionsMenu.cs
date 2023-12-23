using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Slider slider;

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void Start()
    {

        float volume = PlayerPrefs.GetFloat("Volume", slider.maxValue);
        SetVolume(volume);

        slider.value = volume;

    }



    public void SetVolume(float volume)
    {

        SaveVolume(volume);

    }

    public void SaveVolume(float volume)
    {

        PlayerPrefs.SetFloat("Volume", volume);
        Debug.Log("The volume is " + volume);

    }
}
