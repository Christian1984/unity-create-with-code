using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private float speed = 0;
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;

    [SerializeField] private ParticleSystem fxExplosion;
    [SerializeField] private ParticleSystem fxDirtSplatter;

    [SerializeField] private AudioClip soundJump;
    [SerializeField] private AudioClip soundCrash;

    private Rigidbody rb;
    private Animator anim;
    private AudioSource audio;

    private bool isOnGround = false;
    public bool isGameOver { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;

            if (rb)
            {
                rb.AddForce(Vector3.up * jumpForce, forceMode);
            }

            if (anim)
            {
                anim.SetTrigger("Jump_trig");
            }

            if (fxDirtSplatter)
            {
                fxDirtSplatter.Stop();
            }

            // play crash sound
            if (audio && soundJump)
            {
                audio.PlayOneShot(soundJump, 0.75f);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;

            if (fxDirtSplatter)
            {
                fxDirtSplatter.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            // play death animation
            if(anim)
            {
                anim.SetBool("Death_b", true);
            }

            // play explosion particle system
            if (fxExplosion)
            {
                fxExplosion.Play();
            }

            // stop dirt particle system
            if (fxDirtSplatter)
            {
                fxDirtSplatter.Stop();
            }

            // play crash sound
            if (audio && soundCrash)
            {
                audio.PlayOneShot(soundCrash, 1.0f);
            }

            // apply force to obstacle so that it falls over
            Rigidbody collisionRb = collision.gameObject.GetComponent<Rigidbody>();
            if (collisionRb)
            {
                collisionRb.AddForce(Vector3.right, forceMode);
            }

            isGameOver = true;
        }
    }

    public float GetSpeed() 
    {
        return speed;
    }

    public void IncreaseSpeed(float amount)
    {
        if (isGameOver) return;

        speed += amount;
        Debug.Log("New Speed: " + speed);

        if (anim)
        {
            anim.SetFloat("RunSpeedAnimFactor_f", speed / 10f);
        }
    }
}
