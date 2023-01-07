using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float SensX;
    public float SensY;

    public Transform orientation;

    public float smoothTime;
    public Vector3 currentVelocity; 

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get keyboard input
        float horizontalvertical = Input.GetAxisRaw("Vertical");

        //Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        yRotation += mouseX;
      
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate camera orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        rotatePersonage(horizontalvertical);
    }

    void rotatePersonage(float horizontalvertical)
    {
        if (horizontalvertical < 0)
        {
            transform.Rotate(0, 180, 0);
            transform.position = Vector3.SmoothDamp(transform.position, orientation.position - new Vector3(0, -1, -3), ref currentVelocity, smoothTime);
        }
    }
}
