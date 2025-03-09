using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanastaScript : MonoBehaviour
{
    public Rigidbody2D canastaRigidbody;
    public LogicScript logic;
    public AudioManagerScript audioManager;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }

    void Update()
    {
        if (logic.isAlive)
        {

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space))
            {
                canastaRigidbody.velocity = Vector2.left * 20;
                audioManager.Play("line", 1.0f, 1.0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space))
            {
                canastaRigidbody.velocity = Vector2.right * 20;
                audioManager.Play("line", 1.0f, 1.0f);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                canastaRigidbody.velocity = Vector2.left * 8;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                canastaRigidbody.velocity = Vector2.right * 8;
            }
        }
    }
}
