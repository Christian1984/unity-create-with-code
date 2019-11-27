using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2;
    [SerializeField] private GameObject[] TargetPrefabs = null;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTarget", 0, spawnInterval);
    }

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

    public void StopSpawning()
    {
        CancelInvoke("SpawnTarget");
    }
}
