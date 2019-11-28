using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float baseSpawnInterval = 2;
    [SerializeField] private GameObject[] TargetPrefabs = null;

    void SpawnTarget()
    {
        if (TargetPrefabs != null)
        {
            int idx = Random.Range(0, TargetPrefabs.Length);

            if (TargetPrefabs[idx])
            {
                Instantiate(TargetPrefabs[idx]);
            }
        }
    }

    public void StartSpawning(int difficulty)
    {
        if (difficulty < 1) difficulty = 1;
        InvokeRepeating("SpawnTarget", 0, baseSpawnInterval / difficulty);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnTarget");
    }
}
