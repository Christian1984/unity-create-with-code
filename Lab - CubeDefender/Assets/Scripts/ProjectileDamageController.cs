using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageController : MonoBehaviour
{
    [SerializeField] float damage = 0;

    private int spawningGameObjectId = -1;

    public void SetSpawningGameObjectId(int id)
    {
        spawningGameObjectId = id;
    }

    void OnTriggerEnter(Collider collider)
    {
        // do not collide with own spawner
        if (collider.gameObject.GetInstanceID() == spawningGameObjectId)
        {
            //Debug.Log("Projectile collided with own spawner...");
            return;
        }

        // prevent friendly fire, i.e. only damage enemies
        if (collider.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Projectile collided with enemy!");
            DamageController damageController = collider.gameObject.GetComponent<DamageController>();

            if (damageController)
            {
                damageController.DealDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
