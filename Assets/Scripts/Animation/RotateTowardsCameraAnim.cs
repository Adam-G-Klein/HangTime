using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCameraAnim : MonoBehaviour
{

    private GameObject cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = cam.transform.eulerAngles;
    }
}
