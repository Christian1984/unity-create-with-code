using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int daySeconds = 0;

    GuiController guiController = null;

    private int currentSecond = 0;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        guiController = GameObject.FindObjectOfType<GuiController>();
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

        for (int i = 0; i < wave; i++)
        {
            int idx = Random.Range(0, zombieSpawners.Length);
            zombieSpawners[idx].Spawn();
        }
    }
}
