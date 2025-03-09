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
                // fruits will spawn at different angles
                Vector3 rotationVector = new Vector3(0, 0, Random.Range(0, 360));
                // fruits will spawn at different distances
                Instantiate(frutas[Random.Range(0, 5)], new Vector3(Random.Range(-maxDistance, maxDistance), transform.position.y, 0), Quaternion.Euler(rotationVector));
                // fruits will spawn at random intervals of time
                whenToSpawn = Random.Range(1.5f, 3f);
                // timer reset
                timer = 0;
            }
        }
    }
}