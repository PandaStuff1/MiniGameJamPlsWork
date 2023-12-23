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

    [SerializeField]
    private GameObject test;

    [SerializeField]
    private GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        interactButton = GetComponent<Button>();
        GameController = GameObject.Find("GameController");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            instance = Instantiate(test, new Vector2(worldPosition.x, worldPosition.y), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            if (interactType == "Lamp")
            {
                GameController.GetComponent<GameController>().lightOn();
            }
            else if (interactType == "Door")
            {
                GameController.GetComponent<GameController>().doorLock();
            }
            else if (interactType == "Curtain")
            {
                GameController.GetComponent<GameController>().curtainClose();
            }
            else if (interactType == "Wardrobe")
            {
                GameController.GetComponent<GameController>().drawerClose();
            }
        }
        Destroy(instance);
    }
}