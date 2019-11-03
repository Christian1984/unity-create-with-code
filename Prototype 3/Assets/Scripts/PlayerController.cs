using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private float speed = 0;
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;

    private Rigidbody rb = null;
    private bool isOnGround = false;
    public bool isGameOver { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            isGameOver = true;
        }
    }

    public float getSpeed() 
    {
        return speed;
    }
}
