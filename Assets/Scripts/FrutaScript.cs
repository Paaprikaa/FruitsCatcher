using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaScript : MonoBehaviour
{
    public LogicScript logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // The only trigger is 'Basket Trigger'
    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.AddScore(1);
        Destroy(gameObject);
    }

    // if is not 'Basket Trigger', then you lose the game
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        logic.GameOver();
    }
}
