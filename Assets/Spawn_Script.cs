using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Script : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] meteors;

    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawn");
        SpawnMeteors(3);
    }

    public void SpawnMeteors(int numOfMeteors)
    {
        Vector2 ranDir;
        for (int i = 0; i < numOfMeteors; i++)
        {
            int ran = Random.Range(0, spawners.Length);
            int ranMet = Random.Range(0, 2);
            GameObject clone = Instantiate(meteors[ranMet], spawners[ran].transform.position, Quaternion.identity);

            float ranX = Random.Range(-5, 5);
            float ranY = Random.Range(-3, 3);

            ranDir = new Vector2(ranX, ranY);

            clone.transform.up = (ranDir - (Vector2)clone.transform.position).normalized;

        }
    }
}
