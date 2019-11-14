using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int daySeconds = 0;

    [SerializeField] private int numZombiesPerWaveIncrement = 0;
    [SerializeField] private int numZombiesRandomRange = 0;

    GuiController guiController = null;

    private int currentSecond = 0;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        guiController = GameObject.FindObjectOfType<GuiController>();
        SpawnWave();
        InvokeRepeating("TickSecond", 0, 1);
    }

    private void TickSecond()
    {
        currentSecond++;

        if (currentSecond > daySeconds)
        {
            currentSecond = 0;
        }

        if (currentSecond == 0)
        {
            SpawnWave();
        }

        if (guiController)
        {
            guiController.UpdateTimer((float) currentSecond / daySeconds);
        }
    }

    private void SpawnWave() 
    {
        wave++;
        
        ZombieSpawner[] zombieSpawners = GameObject.FindObjectsOfType<ZombieSpawner>();

        if (zombieSpawners.Length <= 0) return;

        int numZombiesStatic = wave * numZombiesPerWaveIncrement;
        int numZombiesRandomized = Random.Range(numZombiesStatic - numZombiesRandomRange, numZombiesStatic + numZombiesRandomRange);
        int numZombiesToSpawn = numZombiesRandomized >= 1 ? numZombiesRandomized : 1;

        for (int i = 0; i < numZombiesToSpawn; i++)
        {
            int idx = Random.Range(0, zombieSpawners.Length);
            zombieSpawners[idx].Spawn();
        }
    }
}
