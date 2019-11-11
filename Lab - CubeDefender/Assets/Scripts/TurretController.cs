using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private float range = 0;

    private ProjectileEmitter gun = null;

    private GameObject currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<ProjectileEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: this is somewhat ugly and buggy. fix!
        if (!currentTarget)
        {
            GameObject closest = GetClosestEnemy();

            if (closest)
            {
                Debug.DrawLine(transform.position + 2 * transform.up, closest.transform.position, Color.white);

                if (closest && Vector3.Distance(closest.transform.position, transform.position) <= range)
                {
                    LockOnTarget(closest);
                }
                else
                {
                    currentTarget = null;
                }
            }
        }
        else
        {
            if (Vector3.Distance(currentTarget.transform.position, transform.position) > range)
            {
                currentTarget = null;
            }
        }

        AttackTarget();
    }

    private GameObject GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject closest = null;
        float minSqDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float sqDist = Vector3.SqrMagnitude(enemy.transform.position - transform.position);

            if (sqDist < minSqDist)
            {
                closest = enemy;
                minSqDist = sqDist;
            }
        }

        return closest;
    }

    private void LockOnTarget(GameObject newTarget)
    {
        currentTarget = newTarget;
    }

    private void AttackTarget()
    {
        if (currentTarget)
        {
            Debug.DrawLine(transform.position + 2 * transform.up, currentTarget.transform.position, Color.red);

            if (gun)
            {
                Vector3 gunPos = transform.position + 2 * transform.up;
                Vector3 dir = (currentTarget.transform.position - gunPos).normalized;

                gun.PullTrigger(projectile, gunPos + dir, Quaternion.LookRotation(dir));
            }
        }
    }
}
