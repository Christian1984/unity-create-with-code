using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private float range = 0;
    [SerializeField] private float cadence = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closest = GetClosestEnemy();

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
        Debug.DrawLine(transform.position, target.transform.position);
    }
}
