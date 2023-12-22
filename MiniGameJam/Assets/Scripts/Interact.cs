using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private Button interactButton;
    [SerializeField]
    private GameObject GameController;
    [SerializeField]
    private string interactType;
    // Start is called before the first frame update
    void Start()
    {
        interactButton = GetComponent<Button>();
        GameController = GameObject.Find("GameController");
    }

    public void OnClick()
    {
        Debug.Log("click");
        if (interactType == "Lamp")
        {
            Debug.Log("call1");
            GameController.GetComponent<GameController>().lightOff();
        }
        else if (interactType == "Door")
        {
            Debug.Log("call2");
            GameController.GetComponent<GameController>().doorLock();
        }
        else if (interactType == "Curtain")
        {
            Debug.Log("call3");
            GameController.GetComponent<GameController>().curtainClose();
        }
        else if (interactType == "Wardrobe")
        {
            Debug.Log("call4");
            GameController.GetComponent<GameController>().drawerClose();
        }
    }
}