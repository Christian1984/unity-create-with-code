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

    [SerializeField] private GameObject[] buildPrefabs = null;

    private ProjectileEmitter gun = null;
    private Rigidbody rb = null;
    private Camera cam = null;
    private int currentBuildPrefab = 0;

    private GuiController guiController = null;

    private bool canMove = true;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<ProjectileEmitter>();
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();

        guiController = FindObjectOfType<GuiController>();

        SelectBuildPrefab(true);
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
        bool build = Input.GetButtonDown("Fire2");
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

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

        // select build prefab
        if (mouseWheel != 0)
        {
            SelectBuildPrefab(mouseWheel > 0);
        }

        if (build)
        {
            Build();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void SelectBuildPrefab(bool up)
    {
        if (buildPrefabs.Length <= 0) return;

        if (up)
        {
            currentBuildPrefab++;
        }
        else
        {
            currentBuildPrefab--;
        }

        if (currentBuildPrefab >= buildPrefabs.Length)
        {
            currentBuildPrefab = -1;
        }
        else if (currentBuildPrefab < -1)
        {
            currentBuildPrefab = buildPrefabs.Length - 1;
        }

        if (guiController)
        {
            guiController.UpdateSelectedBuildText(currentBuildPrefab >= 0 ? buildPrefabs[currentBuildPrefab].name : "[None]");
        }

        Debug.Log("currentBuildPrefab: " + currentBuildPrefab);
    }

    private void Build()
    {
        if (currentBuildPrefab == -1) return;

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 15))
        {
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                GameObject toBuild = buildPrefabs[currentBuildPrefab];
                Instantiate(toBuild, hit.point, toBuild.transform.rotation);
            }
        }
    }
}
