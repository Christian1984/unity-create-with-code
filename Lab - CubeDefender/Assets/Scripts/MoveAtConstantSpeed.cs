using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtConstantSpeed : MonoBehaviour
{
    [SerializeField] private Vector3 speed = Vector3.zero;
    [SerializeField] private float maxTavelDistance = 0;

    private float distanceTravelled = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
        distanceTravelled += speed.magnitude * Time.deltaTime;

        if (maxTavelDistance > 0 && distanceTravelled > maxTavelDistance)
        {
            Destroy(gameObject);
        }
    }
}
