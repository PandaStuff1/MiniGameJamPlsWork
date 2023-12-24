using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int counter = 0;
    [SerializeField]
    public int totalSheep = 0;
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
    private GameObject interactObject;


    enum Ambience
    { 
        CurtainsClose,
        DoorLock,
        DoorCreak,
        CurtainsOpen,
        SpookyTapping,
        Car,
        Door,
        LightOn,
        LightOff,
        DrawerOpen,
        DrawerClose,
        Steps,
        Fox,
        FrameRattle,
        Heart125,
        Heart150,
        Heart200,
        HeartSlow,
        KnockOnce,
        KnockTwice,
        SpookyNoise,
        SpookyThud,
        Tapping,
        Monster
    }

    [SerializeField]
    private float roundTimer = 60;
    private float currentTime = 0;
    [SerializeField]
    private GameObject bg;
    [SerializeField]
    private Sprite[] bgSprite = new Sprite[6];
    [SerializeField]
    private float monsterTime = 10;
    [SerializeField]
    private float monsterRange = 3;
    private float monsterMod = 0;
    [SerializeField]
    private float timeToDeath = 5;
    private int currentEvent = 0;
    [SerializeField]
    private GameObject[] interactables = new GameObject[4];
    private bool monsterActive = false;
    [SerializeField]
    private YouKindOfWin badWin;

    //new
    public float newTimer = 0;
    //private int randomsound = 0;
    //public bool soundActive = false;

    void Start()
    {
        remainingTime = spawnTimer;
        audioSource = GetComponent<AudioSource>();
        monsterMod = Random.Range(monsterRange, -monsterRange);

        //alice added this for the volume slider
        audioSource.volume = PlayerPrefs.GetFloat("Volume");

        Invoke("Monster", 0f);

    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        currentTime += Time.deltaTime;

        //new
        newTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            addCounter();
        }
        if(remainingTime <= 0 & currentTime <= 58)
        {
            spawnSheep();
            remainingTime = spawnTimer - timerMod;
        }
        if(currentTime >= roundTimer)
        {
            currRound++;
            //if (counter <= totalSheep + 5 || counter >= totalSheep - 5)
            if (counter == totalSheep)
            {
                this.enabled = false;
                SceneManager.LoadScene("YouWin", LoadSceneMode.Additive);
            }
            else
            {
                this.enabled = false;
                badWin.SetSheep(counter);
                badWin.SetTotalSheep(totalSheep);
                SceneManager.LoadScene("YouKindOfWin", LoadSceneMode.Additive);
            }
        }

        //Invoke("RandomSound", 16f);
  
    }

    public void Monster()
    {
        if (currentTime >= monsterTime + monsterMod)
        {
            if (monsterActive == false)
            {
                monsterActive = true;
                currentEvent = Random.Range(1, 5);
                bg.GetComponent<SpriteRenderer>().sprite = bgSprite[currentEvent];
                if (currentEvent == 1) { lightOff(); }
                else if (currentEvent == 2) { doorCreak(); }
                else if (currentEvent == 3) { drawerOpen(); }
                else if (currentEvent == 4) { curtainOpen(); }
                else if (currentEvent == 5) { monsterNoise(); }

                newTimer = 0f;

            }
            //if (currentTime >= currentTime + timeToDeath)

            if (newTimer >= 5f & currentEvent != 5) //new
            {
                this.enabled = false;
                SceneManager.LoadScene("Youlose", LoadSceneMode.Additive);
            }
        }

        Invoke("Monster", Random.Range(5f, 7f));
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


    //i was trying to make ambient noises but idk hopw and this didnt work
    /*public void RandomSound()
    {
        soundActive = false;

        if (soundActive == false)
        {
            randomsound = Random.Range(1, 12);
            if (randomsound == 1) { footsteps(); }
            else if (randomsound == 2) { heartbeat125(); }
            else if (randomsound == 3) { heartbeat150(); }
            else if (randomsound == 4) { heartbeat200(); }
            else if (randomsound == 5) { heartbeatSlow(); }
            else if (randomsound == 6) { knocking1(); }
            else if (randomsound == 7) { knocking2(); }
            else if (randomsound == 8) { nightAmbience(); }
            else if (randomsound == 9) { spookyNoise(); }
            else if (randomsound == 10) { spookyTapping(); }
            else if (randomsound == 11) { spookyThud(); }
            else if (randomsound == 12) { tapping(); }
        }
    }*/


    #region Sound jazz

    private void monsterNoise()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Monster];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        Debug.Log("monster noise called");
    }

    private void curtainOpen()
    {
        audioSource.clip = ambientNoises[(int)Ambience.CurtainsOpen];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        interactObject = Instantiate(interactables[0], new Vector2(-1.67f, -1.47f), Quaternion.identity);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[2];
    }

    public void curtainClose()
    {
        audioSource.clip = ambientNoises[(int)Ambience.CurtainsClose];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[0];
        Destroy(interactObject);
        monsterActive = false;
        //monsterTime += currentTime;
    }

    private void doorCreak()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DoorCreak];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        interactObject = Instantiate(interactables[1], new Vector2(6.31f, -3.64f), Quaternion.identity);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[3];
    }

    public void doorLock()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DoorLock];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[0];
        Destroy(interactObject);
        monsterActive = false;
        //monsterTime += currentTime;
    }

    public void lightOff()
    {
        audioSource.clip = ambientNoises[(int)Ambience.LightOff];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        interactObject = Instantiate(interactables[2], new Vector2(-2.38f, -4.2f), Quaternion.identity);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[1];
    }
    public void lightOn()
    {
        audioSource.clip = ambientNoises[(int)Ambience.LightOn];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[0];
        Destroy(interactObject);
        monsterActive = false;
        //monsterTime += currentTime;
    }

    private void drawerOpen()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DoorCreak];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        interactObject = Instantiate(interactables[3], new Vector2(1.93f, -3.64f), Quaternion.identity);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[4];
    }

    public void drawerClose()
    {
        audioSource.clip = ambientNoises[(int)Ambience.DoorLock];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
        bg.GetComponent<SpriteRenderer>().sprite = bgSprite[0];
        Destroy(interactObject);
        monsterActive = false;
        //monsterTime += currentTime;
    }


    private void footsteps()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Steps];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void heartbeat125()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Heart125];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void heartbeat150()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Heart150];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void heartbeat200()
    {
        audioSource.clip = ambientNoises[(int)Ambience.Heart200];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    private void heartbeatSlow()
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


    /*private void nightAmbience()
    {
        audioSource.clip = ambientNoises[(int)Ambience.NightAmbience];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }*/

    private void spookyNoise()
    {
        audioSource.clip = ambientNoises[(int)Ambience.SpookyNoise];
        audioSource.PlayOneShot(audioSource.clip, 0.2f);
    }

    public void spookyTapping()
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