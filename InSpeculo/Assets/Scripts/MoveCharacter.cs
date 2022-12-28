using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{

    public float movementSpeed;
    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalvertical = Input.GetAxisRaw("Vertical");
        
        horizontalvertical = rotatePersonage(horizontalvertical); 
        transform.Translate(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);
        transform.Translate(0, 0, horizontalvertical * movementSpeed * Time.deltaTime);

    }
    float rotatePersonage(float horizontalvertical)
    { 
        if(horizontalvertical < 0)
        {
            transform.Rotate(0, 180, 0);
            return horizontalvertical = horizontalvertical * -1; 
        }
        return horizontalvertical; 
    }
}
