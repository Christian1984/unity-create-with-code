using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int daySeconds = 0;

    private int currentSecond = 0;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TickSecond", 0, 1);
    }

    private void TickSecond()
    {
        if (currentSecond > daySeconds)
        {
            currentSecond = 0;
        }

        if (currentSecond == 0)
        {
            SpawnWave();
        }

        currentSecond++;
    }

    private void SpawnWave() 
    {
        wave++;
        
        ZombieSpawner[] zombieSpawners = GameObject.FindObjectsOfType<ZombieSpawner>();

        if (zombieSpawners.Length <= 0) return;

        for (int i = 0; i < wave; i++)
        {
            int idx = Random.Range(0, zombieSpawners.Length);
            zombieSpawners[idx].Spawn();
        }
    }
}
