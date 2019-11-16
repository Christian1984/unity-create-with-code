using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private float size = 0;
    [SerializeField] private float offset = 0;

    private Camera miniMapCamera = null;
    // Start is called before the first frame update

    void Start()
    {
        miniMapCamera = GetComponent<Camera>();

        if (miniMapCamera && mainCamera)
        {
            float height = size;
            float width = size / mainCamera.aspect;

            float x = 1 - width - offset;
            float y = offset;

            miniMapCamera.rect = new Rect(x, y, width, height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
