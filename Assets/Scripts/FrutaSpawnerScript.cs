using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaSpawnerScript : MonoBehaviour
{
    public GameObject[] frutas;
    private float timer = 0;
    private float maxDistance = 8.45f;
    private float whenToSpawn;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        whenToSpawn = Random.Range(1.5f, 3f);

    }

    void Update()
    {
        if (logic.isAlive)
        {
            if (timer < whenToSpawn)
            {
                timer += Time.deltaTime;
            }
            else
            {
                // fruits will spawn at different distances
                Instantiate(frutas[Random.Range(0, 5)], new Vector3(Random.Range(-maxDistance, maxDistance), transform.position.y, 0), new Quaternion(0, 0, Random.Range(0, 365), 1));
                // fruits will spawn at random intervals of time
                whenToSpawn = Random.Range(1.5f, 3f);
                // timer reset
                timer = 0;
            }
        }
    }
}