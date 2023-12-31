using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class YouKindOfWin : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textElement;
    //static public int sheepCount = 0;
    //static public int totalSheep = 0;

    public void Start()
    {
        float sheepCount = PlayerPrefs.GetFloat("counter", 0);
        float totalSheep = PlayerPrefs.GetFloat("totalSheep", 0);

        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "YouKindOfWin")
        {
            textElement = GetComponent<TextMeshProUGUI>();
            textElement.text = "You counted " + sheepCount + " out of " + totalSheep + " sheep.";

        }*/

        //alice added this
        //Debug.Log("start called, scene name: " + sceneName);
        textElement.text = "You counted " + sheepCount.ToString() + " out of " + totalSheep.ToString() + " sheep.";

    }

    /*public void SetSheep(int sheep)
    {
        sheepCount = sheep;
    }

    public void SetTotalSheep(int total)
    {
        totalSheep = total;
    }

    public void RestartButton()
    {
        
        SceneManager.LoadScene("SampleScene");

    }*/

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
