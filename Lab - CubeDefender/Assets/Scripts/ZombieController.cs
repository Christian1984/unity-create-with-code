using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    private Rigidbody rb;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("CompanionCube");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        transform.forward = targetDir;

        if (rb)
        {
            Vector3 hVelocity = new Vector3(targetDir.x, 0, targetDir.z).normalized * speed;
            rb.velocity = hVelocity + rb.velocity.y * Vector3.up;
        }
    }
}
