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
        Debug.Log("ENTER COLLISION");
        if (collision.gameObject.CompareTag("Basket") &&
            collision.transform.GetChild(1).gameObject.CompareTag("Basket"))
        {
            Debug.Log("should add 1");
            Destroy(gameObject);
            logic.AddScore(1);
        }
        else
        {
            Debug.Log("should lost");
            Destroy(gameObject);
            logic.GameOver();

        }
    }
}
