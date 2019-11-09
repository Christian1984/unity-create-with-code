using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float health = 0;

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
            Destroy(gameObject);
        }
    }
}
