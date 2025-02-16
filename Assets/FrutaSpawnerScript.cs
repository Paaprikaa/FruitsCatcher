using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaSpawnerScript : MonoBehaviour
{
    public GameObject[] frutas;
    private float timer = 0;
    private float maxDistance = 8.45f;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (logic.isAlive)
        {
            if (timer < 2)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Instantiate(frutas[Random.Range(0, 5)], new Vector3(Random.Range(-maxDistance, maxDistance), transform.position.y, 0), new Quaternion(0, 0 , Random.Range(0,365), 1));
                // Debug.Log("timer: " + timer);
                timer = 0;
                // Debug.Log("timer restart");
            }
        }
    }
}
