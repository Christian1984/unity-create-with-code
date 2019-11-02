using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float boundsX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);

        if (transform.position.x < -boundsX) {
            transform.position = new Vector3(-boundsX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundsX) {
            transform.position = new Vector3(boundsX, transform.position.y, transform.position.z);
        }
    }
}
