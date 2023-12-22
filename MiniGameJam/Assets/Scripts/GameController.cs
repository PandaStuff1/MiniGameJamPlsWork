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
    private float spawnTimer = 0.25f;
    private float remainingTime = 0;
    [SerializeField]
    private GameObject sheep;
    [SerializeField]
    private Vector2 spawnPos = new Vector2(7, 3.5f);
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
        textElement.text = counter.ToString();
        Debug.Log(counter);
    }

    private void spawnSheep()
    {
        totalSheep++;

        //Vector2 spawnPos = new Vector2(transform.position.x, tr);
        Instantiate(sheep, spawnPos, Quaternion.identity);

        
    }

    private void doorCreak()
    {
        audioSource.clip = door;
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void curtainClose()
    {

    }

    private void curtainOpen()
    {

    }

    private void doorLock()
    {

    }

    private void drawerOpen()
    {

    }

    private void drawerClose()
    {

    }

    private void footsteps()
    {

    }

    private void heartbeat()
    {

    }

    private void heartbeat125()
    {

    }

    private void hearbeat150()
    {

    }

    private void heartbeat200()
    {

    }

    private void hearbeat50()
    {

    }

    private void knocking1()
    {

    }

    private void knocking2()
    {

    }

    private void lightOn()
    {

    }

    private void lightOff()
    {

    }

    private void nightAmbience()
    {

    }

    private void spookyNoise()
    {

    }

    private void spookyTapping()
    {

    }

    private void spookyThud()
    {

    }

    private void tapping()
    {

    }
}
