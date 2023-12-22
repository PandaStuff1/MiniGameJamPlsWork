using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int counter = 0;
    [SerializeField]
    private int totalSheep = 0;
    [SerializeField]
    private int totalRounds = 3;
    private int currRound = 0;
    [SerializeField]
    private float spawnTimer = 3;
    private float remainingTime = 0;
    [SerializeField]
    private GameObject sheep;
    [SerializeField]
    private Vector2 spawnPos = new Vector2(10, 3);
    [SerializeField]
    private TextMeshPro textElement;


    void Start()
    {
        remainingTime = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            addCounter();
        }
        if(remainingTime<=0)
        {
            spawnSheep();
            remainingTime = spawnTimer;
        }
        
    }

    private void addCounter()
    {
        counter++;
        textElement.text = counter.ToString();
        Debug.Log(counter);
    }

    private void spawnSheep()
    {
        totalSheep++;

        Vector2 spawnPos = new Vector2(transform.position.x, Random.Range(1.0f, 5.0f));
        Instantiate(sheep, spawnPos, Quaternion.identity);

        
    }
}
