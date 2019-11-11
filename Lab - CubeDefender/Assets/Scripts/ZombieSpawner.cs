using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie = null;
    [SerializeField] private float maxSpawnRange = 0;

    public void Spawn()
    {
        float distance = maxSpawnRange > 1 ? Random.Range(1, maxSpawnRange) : 1;
        float angle = Random.Range(0, 360);
        Vector3 pos = transform.position + Vector3.up + Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Instantiate(zombie, pos, zombie.transform.rotation);
    }
}
