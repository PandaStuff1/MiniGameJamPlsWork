using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    private Vector2 spawnPos = Vector2.zero;

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
        Debug.Log(counter);
    }

    private void spawnSheep()
    {
        totalSheep++;
        Instantiate(sheep, spawnPos, Quaternion.identity);
    }
}
