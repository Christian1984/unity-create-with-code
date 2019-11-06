using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocity = 0;
    [SerializeField] private GameObject focalPoint;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (focalPoint)
        {
            rb.AddForce(focalPoint.transform.forward * velocity * Time.deltaTime);
        }
    }
}
