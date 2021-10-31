using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject[] gas;

    public float timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int randomGas = Random.Range(0, gas.Length);
            int randomSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(gas[randomGas], spawnPoints[randomSpawn].transform.position, gameObject.transform.rotation);
            timer = 3f;
        }
    }
}
