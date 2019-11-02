using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public static float topBound = 30;
    public static float bottomBound = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound) {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBound) {
            Destroy(gameObject);
            Debug.Log("!!! Game Over !!!");
        }
    }
}
