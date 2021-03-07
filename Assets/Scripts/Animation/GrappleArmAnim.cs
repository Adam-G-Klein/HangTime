using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleArmAnim : MonoBehaviour
{
    private Transform playerFocus;
    private Transform cam;
    private Transform player;

    public float aimDist = 10f;
    public float armLength = 1f;
    public float idleXOffset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        playerFocus = GameObject.FindGameObjectWithTag("PlayerFocus").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimLoc = getAimLoc();
        transform.position = getOutstrechedHandPos(aimLoc);
    }

    private Vector3 getAimLoc(){
        Vector3 retDir = playerFocus.position - cam.position;
        retDir.Normalize();
        return (retDir * aimDist) + playerFocus.position;
    }

    private Vector3 getOutstrechedHandPos(Vector3 aimLoc){
        Vector3 aimDir = (aimLoc - player.position).normalized;
        Vector3 handPos = aimDir * armLength;
        handPos = new Vector3(handPos.x + idleXOffset, handPos.y, handPos.z);
        return handPos;
    }
}
