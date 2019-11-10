using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float range = 0;

    private ProjectileEmitter gun = null;

    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<ProjectileEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closest = GetClosestEnemy();

        Debug.DrawLine(transform.position, closest.transform.position, Color.white);

        if (closest && Vector3.Distance(closest.transform.position, transform.position) <= range)
        {
            AttackTarget(closest);
        }
    }

    private GameObject GetClosestEnemy()
    {
        //TODO
        return GameObject.FindGameObjectWithTag("Enemy");
    }

    private void AttackTarget(GameObject target)
    {
        Debug.DrawLine(transform.position, target.transform.position, Color.red);

        if (gun)
        {
            Vector3 gunPos = transform.position + transform.up;
            Vector3 dir = (target.transform.position - gunPos).normalized;

            gun.PullTrigger(projectile, gunPos + dir, Quaternion.LookRotation(dir));
        }
    }
}
