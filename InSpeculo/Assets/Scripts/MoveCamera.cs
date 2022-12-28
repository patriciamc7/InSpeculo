using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform orientation; 
    public float sens;

    float yRotation;
    float xRotation; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }
    private void Update()
    {
        float horizontalvertical = Input.GetAxisRaw("Vertical");

        

        float mouseX = Input.GetAxisRaw("Mouse X") + Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") + Time.deltaTime * sens;

        yRotation += mouseX;
        if (horizontalvertical < 0)
        {
            mouseY = mouseY * 1; 
        }
            xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); 
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        rotatePersonage(horizontalvertical);
    }
    void rotatePersonage(float horizontalvertical)
    {
        if (horizontalvertical < 0)
        {
            transform.Rotate(0, 180, 0);
            transform.position = Vector3.SmoothDamp(transform.position, orientation.position - new Vector3(0,-1,-3), ref _currentVelocity, smoothTime);
            
        }
       
    }
    #region Variables

    private Vector3 _offset;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    #endregion

    #region Unity callbacks

    private void Awake() => _offset = transform.position - orientation.position;

    private void LateUpdate()
    {
        Vector3 targetPosition = orientation.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

    #endregion


}
