using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    [SerializeField]
    private float sheepSpeed = 5;
    [SerializeField]
    private float speedRange = 1;
    private float speedMod = 0;

    [SerializeField]
    private BoxCollider2D hitBox;

    private GameObject controller;
    
    // Start is called before the first frame update
    void Start()
    {
        hitBox = gameObject.GetComponent<BoxCollider2D>();
        speedMod = Random.Range(speedRange, -speedRange);
        controller = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - (sheepSpeed - speedMod) * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Sheep" && collision.tag != "Counter")
            Destroy(gameObject);

        if(collision.tag == "counter")
        {
            controller.GetComponent<GameController>().totalSheep++;
        }
    }

}
