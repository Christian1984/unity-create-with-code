using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPickup : MonoBehaviour
{
    [SerializeField] private float spawnImpulse = 0;
    [SerializeField] private int value = 0;
    [SerializeField] private int livespanSeconds = 0;

    private Rigidbody rb = null;
    private Collider coll = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(rb);

            if (coll)
            {
                coll.isTrigger = true;
            }
        }
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
