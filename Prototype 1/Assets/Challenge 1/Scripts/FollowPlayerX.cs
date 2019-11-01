using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // chasing cam
        /*
        Vector3 rotOffset = plane.transform.rotation * offset;
        transform.position = plane.transform.position + rotOffset;
        transform.rotation = plane.transform.rotation;
        */

        transform.position = plane.transform.position + offset;


    }
}
