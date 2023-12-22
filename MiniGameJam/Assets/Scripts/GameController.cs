using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int counter = 0;
    [SerializeField]
    private int totalSheep = 0;
    [SerializeField]
    private int totalRounds = 3;
    static private int currRound = 0;
    [SerializeField]
    private float spawnTimer = 3;
    private float remainingTime = 0;
    [SerializeField]
    private GameObject sheep;
    [SerializeField]
    private Vector2 spawnPos = new Vector2(10, 3);
    [SerializeField]
    private TextMeshProUGUI textElement;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip door;


    void Start()
    {
        remainingTime = spawnTimer;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            addCounter();
            doorCreak();
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
        //textElement.text = counter.ToString();
        Debug.Log(counter);
    }

    private void spawnSheep()
    {
        totalSheep++;

        Vector2 spawnPos = new Vector2(transform.position.x, Random.Range(1.0f, 5.0f));
        Instantiate(sheep, spawnPos, Quaternion.identity);

        
    }

    private void doorCreak()
    {
        audioSource.clip = door;
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }


}
