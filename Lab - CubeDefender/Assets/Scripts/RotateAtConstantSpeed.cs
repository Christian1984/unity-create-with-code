using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAtConstantSpeed : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = Vector3.zero;
    [SerializeField] private bool worldSpace = true;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, worldSpace ? Space.World : Space.Self);
    }
}
