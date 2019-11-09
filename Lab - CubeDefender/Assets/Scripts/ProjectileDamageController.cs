using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageController : MonoBehaviour
{
    [SerializeField] float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Projectile collided!");

        GameObject other = collider.gameObject;
        DamageController damageController = other.GetComponent<DamageController>();

        if (damageController)
        {
            damageController.DealDamage(damage);
        }

        Destroy(gameObject);
    }
}
