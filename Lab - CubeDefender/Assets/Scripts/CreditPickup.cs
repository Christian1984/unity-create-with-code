using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPickup : MonoBehaviour
{
    [SerializeField] private float spawnImpulse = 0;
    [SerializeField] private int value = 0;
    [SerializeField] private int livespanSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            float angle = Random.Range(0, 360);
            Vector3 hDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;

            transform.Translate(hDir);
            float randSpawnImpulse = Random.Range(0.5f * spawnImpulse, 1.5f * spawnImpulse);
            rb.AddForce((Vector3.up + hDir) * randSpawnImpulse, ForceMode.Impulse);
        }

        Invoke("Die", livespanSeconds);
    }

    public int getValue()
    {
        return value;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
