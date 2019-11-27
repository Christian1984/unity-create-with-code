using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float forceMin = 12;
    [SerializeField] private float forceMax = 16;

    [SerializeField] private float torqueMax = 10;

    [SerializeField] private float initialY = -2;
    [SerializeField] private float initialPosXRange = 4;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-initialPosXRange, initialPosXRange), initialY, 0);

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.up * Random.Range(forceMin, forceMax), ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(-torqueMax, torqueMax), Random.Range(-torqueMax, torqueMax), Random.Range(-torqueMax, torqueMax)), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
