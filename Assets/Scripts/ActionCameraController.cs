using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCameraController : MonoBehaviour
{

    public Transform focusTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = .05f;
    public bool RotateAroundPlayer = true;

    public float MaxRotationSpeed = 4f;
    public float RotationSpeedMulitplier = 1.5f;
    private float angleOfRotation;
    void Start()
    {
        cameraOffset = transform.position - focusTransform.position;
        angleOfRotation = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
                
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector2 mouseMove = new Vector2(mouseX, mouseY);
            //Debug.Log(mouseMove);
            mouseMove = mouseMove.normalized;
            //Debug.Log(mouseMove);
            mouseMove = mouseMove * RotationSpeedMulitplier;
            
            //Debug.Log(mouseMove);

            if (mouseX > 0){
                mouseX = Mathf.Min(mouseMove.x, MaxRotationSpeed);
            }
            else if(mouseX < 0) {
                mouseX = Mathf.Max(mouseMove.x, -MaxRotationSpeed);
            }  
            Quaternion camTurnAngleX = 
                Quaternion.AngleAxis(mouseX, Vector3.up);

            if (mouseY > 0){
                mouseY = Mathf.Min(mouseMove.y, MaxRotationSpeed);
            }
            else if(mouseY < 0) {
                mouseY = Mathf.Max(mouseMove.y, -MaxRotationSpeed);
            }
            Quaternion camTurnAngleY =  
                Quaternion.AngleAxis(mouseY, transform.right);
            

            //angleOfRotation += mouseY;
            float angle = transform.eulerAngles.x;
            //Debug.Log(transform.eulerAngles.x);
            if((mouseY > 0 && ((angle + mouseY) >= 80) && ((angle + mouseY) < 160)) ||
                (mouseY < 0 && ((angle - mouseY) <= 280) && ((angle - mouseY) > 160)))
            {
                cameraOffset = camTurnAngleX * cameraOffset;

                Vector3 newPos = focusTransform.position + cameraOffset;
                
                //newPos = new Vector3(newPos.x, Mathf.Min(newPos.y, 12.5f - PlayerTransform.position.y), newPos.z);
                transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
                
                transform.LookAt(focusTransform);
            }
            else
            {
                cameraOffset = camTurnAngleX * camTurnAngleY * cameraOffset;

                Vector3 newPos = focusTransform.position + cameraOffset;
                
                //newPos = new Vector3(newPos.x, Mathf.Min(newPos.y, 12.5f - PlayerTransform.position.y), newPos.z);
                transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
                
                transform.LookAt(focusTransform);
            }

            //Debug.Log(transform.eulerAngles.x);


            //code to only allow movement in certain parts of the screen
            /*
                    if(RotateAroundPlayer)
        {
            if (Input.mousePosition.x > Screen.width - SreenRotateZone)
            {
                float mouseX = Input.GetAxis("Mouse X");
                mouseX = Mathf.Min(mouseX, RotationSpeed);
                if (mouseX > 0){
                    Quaternion camTurnAngleX = 
                        Quaternion.AngleAxis(mouseX, Vector3.up);
                    cameraOffset = camTurnAngleX * cameraOffset;
                }
            }            
            else if (Input.mousePosition.x < SreenRotateZone)
            {
                float mouseX = Input.GetAxis("Mouse X");
                if(mouseX < 0) {
                    mouseX = Mathf.Max(mouseX, -RotationSpeed);
                    Quaternion camTurnAngleX =  
                        Quaternion.AngleAxis(mouseX, Vector3.up);
                    cameraOffset = camTurnAngleX * cameraOffset;
                }

            }
            else if (Input.mousePosition.y > Screen.height - SreenRotateZone)
            {
                float mouseY = Input.GetAxis("Mouse Y");
                mouseY = Mathf.Min(mouseY, RotationSpeed);
                if (mouseY > 0){
                    Quaternion camTurnAngleX = 
                        Quaternion.AngleAxis(mouseY, transform.right);
                    cameraOffset = camTurnAngleX * cameraOffset;
                }
            }            
            else if (Input.mousePosition.y < SreenRotateZone)
            {
                float mouseY = Input.GetAxis("Mouse Y");
                if(mouseY < 0) {
                    mouseY = Mathf.Max(mouseY, -RotationSpeed);
                    Quaternion camTurnAngleX =  
                        Quaternion.AngleAxis(mouseY, transform.right);
                    cameraOffset = camTurnAngleX * cameraOffset;
                }

            }
            */
            
            // The following code only kind of works and doesnt really add a whole lot to the experience
            /*else if (Input.mousePosition.y > Screen.height - 30)
            {
                Quaternion camTurnAngleX = 
                    Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.right);
                cameraOffset = camTurnAngleX * cameraOffset;
            }
            else if (Input.mousePosition.x < 30)
            {
                Quaternion camTurnAngleX = 
                    Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.right);
                cameraOffset = camTurnAngleX * cameraOffset;
            }*/      
        }
        //Debug.Log(cameraOffset);
        //Debug.Log(PlayerTransform.position.y - (PlayerTransform.position + cameraOffset).y);
        //Debug.Log(PlayerTransform.position.y - transform.position.y);
        //Debug.Log(12.5f - PlayerTransform.position.y);
    }
}
