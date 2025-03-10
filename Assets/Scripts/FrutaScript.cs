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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Basket") && collision.transform.GetChild(1).gameObject.CompareTag("Basket"))
        {
            Destroy(gameObject);
            logic.AddScore(1);
        }
        else
        {
            Destroy(gameObject);
            logic.GameOver();

        }
    }
}
