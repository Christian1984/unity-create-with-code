using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotationController : MonoBehaviour
{
    [SerializeField] private Vector3 speed = new Vector3();
    [SerializeField] private bool HasRandomizedSpeed = false;

    private Vector3 instanceSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (HasRandomizedSpeed) {
            instanceSpeed = new Vector3(
                Random.Range(-Mathf.Abs(speed.x), Mathf.Abs(speed.x)),
                Random.Range(-Mathf.Abs(speed.y), Mathf.Abs(speed.y)),
                Random.Range(-Mathf.Abs(speed.z), Mathf.Abs(speed.z))
            );
        }
        else {
            instanceSpeed = speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(instanceSpeed * Time.deltaTime, Space.World);
    }
}
