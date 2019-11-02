using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Vector3 spawnLocation;
    [SerializeField] private Vector3 spawnRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            int idx = Random.Range(0, gameObjects.Length);

            if (gameObjects[idx] != null) {
                Vector3 spawnPos = spawnLocation + new Vector3(
                    Random.Range(-Mathf.Abs(spawnRange.x), Mathf.Abs(spawnRange.x)),
                    Random.Range(-Mathf.Abs(spawnRange.y), Mathf.Abs(spawnRange.y)),
                    Random.Range(-Mathf.Abs(spawnRange.z), Mathf.Abs(spawnRange.z))
                );
                Instantiate(gameObjects[idx], spawnPos, gameObjects[idx].transform.rotation);
            }
        }
    }
}
