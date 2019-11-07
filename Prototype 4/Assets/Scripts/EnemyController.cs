using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float velocity = 0;
    
    private Rigidbody rb = null;
    private GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Fixed Update is called in fixed intervals (do physics manipulation here!)
    void FixedUpdate()
    {
        if (rb && player)
        {
            rb.AddForce((player.transform.position - transform.position).normalized * velocity * Time.deltaTime);
        }
    }
}
