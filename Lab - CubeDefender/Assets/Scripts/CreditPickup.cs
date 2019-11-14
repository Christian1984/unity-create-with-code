using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPickup : MonoBehaviour
{
    [SerializeField] private int value = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            float angle = Random.Range(0, 360);
            rb.AddForce(Vector3.up + Quaternion.Euler(0, angle, 0) * Vector3.right * 10, ForceMode.Impulse);
        }
    }
}
