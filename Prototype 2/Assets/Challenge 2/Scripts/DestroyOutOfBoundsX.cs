using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private static float bottomLimit = -10;
    private static float leftLimit = -60;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update " + gameObject.name);
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }

        // Destroy balls if y position is less than bottomLimit
        if (transform.position.y < leftLimit)
        {
            Destroy(gameObject);
        }

    }
}
