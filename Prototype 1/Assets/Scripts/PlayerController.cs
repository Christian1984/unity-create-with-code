using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private float rotation = 10;
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        var vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);

        var hInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * rotation * hInput * vInput);
    }
}
