using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpeedController : MonoBehaviour
{
    [SerializeField] private Vector3 speed = new Vector3();

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, Space.World);
    }
}
