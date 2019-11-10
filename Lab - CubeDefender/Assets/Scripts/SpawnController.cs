using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
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

        if (enemyPrefab)
        {
            for (int i = 0; i < wave; i++)
            {
                //TODO: randomize spawn pos
                Vector3 pos = new Vector3(2 * i, 0, 10);
                Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
            }
        }
    }
}
