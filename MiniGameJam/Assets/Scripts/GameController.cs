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
    private AudioClip[] ambientNoises = new AudioClip[24];
    [SerializeField]
    private float timerRange = 1;
    private float timerMod = 0;
    enum Ambience
    { 
        Car,
        CurtainsClose,
        CurtainsOpen,
        Door,
        DoorCreak,
        DoorLock,
        DrawerOpen,
        DrawerClose,
        Steps,
        Fox,
        FrameRattle,
        Heart,
        Heart125,
        Heart150,
        Heart200,
        HeartSlow,
        KnockOnce,
        KnockTwice,
        LightOff,
        LightOn,
        NightAmbience,
        SpookyNoise,
        SpookyTapping,
        SpookyThud,
        Tapping,
        Height
    }
    [SerializeField]
    private float roundTimer = 60;
    private float currentTime = 0;
    [SerializeField]
    private GameObject backGround;
    [SerializeField]
    private Sprite[] background = new Sprite[5];
    [SerializeField]
    private float monsterTime = 10;
    [SerializeField]
    private float monsterRange = 3;
    private float monsterMod = 0;


    void Start()
    {
        remainingTime = spawnTimer;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        currentTime += Time.deltaTime * 10;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            addCounter();
            doorCreak();
        }
        if(remainingTime<=0)
        {
            spawnSheep();
            remainingTime = spawnTimer - timerMod;
        }
        if(currentTime >= roundTimer)
        {
            //go to win next stage
            currRound++;
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
        timerMod = Random.Range(timerRange, -timerRange);
        Instantiate(sheep, spawnPos, Quaternion.identity);
    }



    #region Sound jazz
    private void doorCreak()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DoorCreak];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void curtainClose()
    {
        audioSource.clip = ambientNoises[(int)Ambience.CurtainsClose];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void curtainOpen()
    {
        audioSource.clip = ambientNoises[(int)Ambience.CurtainsOpen];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void doorLock()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DoorLock];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void drawerOpen()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DrawerOpen];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void drawerClose()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DrawerClose];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void footsteps()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Steps];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void heartbeat()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Heart];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void heartbeat125()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Heart125];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void hearbeat150()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Heart150];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void heartbeat200()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Heart200];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void hearbeatSlow()
    {
        audioSource.clip = ambientNoises[(int)Ambience.HeartSlow];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void knocking1()
    {
        audioSource.clip = ambientNoises[(int)Ambience.KnockOnce];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void knocking2()
    {
        audioSource.clip = ambientNoises[(int)Ambience.KnockTwice];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void lightOn()
    {
        audioSource.clip = ambientNoises[(int)Ambience.LightOn];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void lightOff()
    {
        audioSource.clip = ambientNoises[(int)Ambience.LightOff];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void nightAmbience()
    {
        audioSource.clip = ambientNoises[(int)Ambience.NightAmbience];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void spookyNoise()
    {
        audioSource.clip = ambientNoises[(int)Ambience.SpookyNoise];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void spookyTapping()
    {
        audioSource.clip = ambientNoises[(int)Ambience.SpookyTapping];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void spookyThud()
    {
        audioSource.clip = ambientNoises[(int)Ambience.SpookyThud];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void tapping()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Tapping];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }
    #endregion
}