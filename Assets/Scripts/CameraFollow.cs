using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float xOffset = 2.0f;
    public float yOffset = 3.0f;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = playerTransform.position + new Vector3(xOffset, yOffset, 0);
    }
}
