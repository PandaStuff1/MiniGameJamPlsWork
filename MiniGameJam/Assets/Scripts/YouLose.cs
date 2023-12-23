using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLose : MonoBehaviour
{

    public void RestartButton()
    {

        SceneManager.LoadScene("SampleScene");

    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
