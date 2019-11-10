using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float speed;

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
        Vector3 hVelocity = new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime;
        rb.velocity = hVelocity + rb.velocity.y * Vector3.up;
    }
}
