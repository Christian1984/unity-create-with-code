using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject head = null;
    [SerializeField] private float maxVelocity = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private float mouseSensitivity = 0;

    [SerializeField] private GameObject projectile = null;

    private ProjectileEmitter gun = null;
    private Rigidbody rb = null;
    private Camera cam = null;

    private bool canMove = true;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<ProjectileEmitter>();
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && rb)
        {
            ProcessPlayerInput();
        }
    }

    void ProcessPlayerInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        bool jump = Input.GetButtonDown("Jump");
        bool fire = Input.GetButtonDown("Fire1");

        // horizontal movement
        Vector2 hInput = (new Vector2(transform.forward.x, transform.forward.z) * zInput +
            new Vector2(transform.right.x, transform.right.z) * xInput);
        Vector2 hVelocity = (hInput.magnitude > 1 ? hInput.normalized : hInput) * maxVelocity;

        rb.velocity = new Vector3(hVelocity.x, rb.velocity.y, hVelocity.y);

        // rotate player & camera
        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0, mouseX * mouseSensitivity * Time.deltaTime, 0));

        if (head)
        {
            //TODO: contraint head movement
            head.transform.Rotate(-mouseY * mouseSensitivity * Time.deltaTime, 0, 0, Space.Self);
        }

        // jumping
        if (jump && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

        // fire
        if (fire && projectile && cam && gun)
        {
            gun.PullTrigger(projectile, cam.transform.position + cam.transform.forward, cam.transform.rotation);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
