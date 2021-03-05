 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpHeight = 7f;
    public bool isGrounded = true;
    
    private Rigidbody rb;
    public ParticleSystem sphereParticles;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector3.up * jumpHeight);
                }
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sphere")
        {
            GameObject GM = GameObject.Find("GrappleManager");
            GM.GetComponent<DrawLines>().stopGrappling();
            other.gameObject.SetActive(false);
            Instantiate(sphereParticles, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}