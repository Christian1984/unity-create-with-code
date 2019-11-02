using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float boundsX = 0;

    [SerializeField] private GameObject foodPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        //float foodInput = Input.GetKeyDown

        // move player
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);

        if (transform.position.x < -boundsX) {
            transform.position = new Vector3(-boundsX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundsX) {
            transform.position = new Vector3(boundsX, transform.position.y, transform.position.z);
        }

        // spawn food
        if (Input.GetKeyDown(KeyCode.Space) && foodPrefab != null) {
            //Instantiate(foodPrefab, transform.position, Quaternion.identity); //this will always spawn the object with the rotation set to (0, 0, 0)
            Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation); //this will always spawn the object with the rotation as set up in the prefab!
        }
    }
}
