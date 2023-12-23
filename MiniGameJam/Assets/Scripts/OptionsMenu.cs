using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider slider;

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void Start()
    {

        float volume = PlayerPrefs.GetFloat("musicVolume", slider.maxValue);
        SetVolume(volume);

        slider.value = volume;

    }



    public void SetVolume(float volume)
    {
        
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);

        SaveVolume(volume);

    }

    public void SaveVolume(float volume)
    {

        PlayerPrefs.SetFloat("musicVolume", volume);
        Debug.Log("The volume is " + volume);

    }
}
