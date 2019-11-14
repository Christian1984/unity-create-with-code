using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    [SerializeField] private float strength = 0;
    [SerializeField] private float coolDown = 0;

    private bool canAttack = true;

    void OnCollisionStay(Collision collision)
    {
        DamageController damageController = collision.gameObject.GetComponent<DamageController>();

        if (!damageController || collision.gameObject.CompareTag("Enemy")) return;

        TryHit(damageController);
    }

    private void TryHit(DamageController damageController)
    {
        if (canAttack)
        {
            damageController.DealDamage(strength);
            canAttack = false;
            Invoke("ResetCanAttack", coolDown);
        }
    }

    private void ResetCanAttack()
    {
        canAttack = true;
    }
}
