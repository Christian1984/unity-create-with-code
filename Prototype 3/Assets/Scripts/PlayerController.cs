using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 0;
    //[SerializeField] static private float gravityModifier = 1;
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;

    private Rigidbody rb = null;
    private bool isOnGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        /*
            I really don't like changing global properties from non-static GameObjects... 
            This feels ugly and in my opinion can lead to unexpected side effects 
            (imagine multiple instances of player with different settings for this property!)
        */
        //Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision) {
        isOnGround = true;
    }
}
