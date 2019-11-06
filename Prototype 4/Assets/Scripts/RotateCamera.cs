using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float axisRotationSpeed = 0;
    [SerializeField] private float mouseRotationSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * axisRotationSpeed;
        float mInput = Input.GetAxis("Mouse X") * mouseRotationSpeed;

        float input = hInput != 0 ? hInput : mInput;

        transform.Rotate(Vector3.up * input * Time.deltaTime);
    }
}
