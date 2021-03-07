using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftTargetCatchupAnim : MonoBehaviour
{

    public Transform target;
    public float catchupRate;
    public float maxDist;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, catchupRate);
        float newDist = (newPos - target.position).magnitude;
        Vector3 maxPosDir = (transform.position - target.position).normalized;
        Vector3 maxDistPos = (maxPosDir * maxDist) + target.position;
        print("newPosDir: " + maxPosDir);
        if(newDist > maxDist){
            print("setting max dist pos: " + maxDistPos);
            transform.position = maxDistPos ;
        }
        else
            transform.position = newPos;

    }
}
