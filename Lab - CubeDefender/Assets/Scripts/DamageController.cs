using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float health = 0;

    [SerializeField] private GameObject spawnOnDeathPrefab = null;
    [SerializeField] private int spawnOnDeathPrefabCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(float damage)
    {
        Debug.Log(damage + " Damage dealt to " + gameObject.name);

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (spawnOnDeathPrefab)
        {
            for (int i = 0; i < spawnOnDeathPrefabCount; i++)
            {
                Instantiate(spawnOnDeathPrefab, transform.position, spawnOnDeathPrefab.transform.rotation);
            }
        }

        GameOverOnDeath go = GetComponent<GameOverOnDeath>();

        if (go)
        {
            go.TriggerGameOver();
        }

        Destroy(gameObject);
    }
}
