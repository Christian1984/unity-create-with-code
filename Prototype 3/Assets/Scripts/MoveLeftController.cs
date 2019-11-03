using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftController : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
