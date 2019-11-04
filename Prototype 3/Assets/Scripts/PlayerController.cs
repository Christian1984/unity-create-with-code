using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private float speed = 0;
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;

    private Rigidbody rb;
    private Animator anim;
    private bool isOnGround = false;
    public bool isGameOver { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            anim.SetTrigger("Jump_trig");
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
            if (!isGameOver)
            {
                if(anim)
                {
                    anim.SetBool("Death_b", true);
                }

                // apply force to obstacle so that it falls over
                Rigidbody collisionRb = collision.gameObject.GetComponent<Rigidbody>();
                if (collisionRb)
                {
                    Debug.Log("Baaam! " + collision.gameObject.name);
                    collisionRb.AddForce(Vector3.right, forceMode);
                }

                isGameOver = true;
            }
        }
    }

    public float GetSpeed() 
    {
        return speed;
    }

    public void IncreaseSpeed(float amount)
    {
        if (!isGameOver)
        {
            speed += amount;
            Debug.Log("New Speed: " + speed);

            if (anim)
            {
                anim.SetFloat("RunSpeedAnimFactor_f", speed / 10f);
            }
        }
    }
}
