using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    private float y;
    
    private float speedOne = 0f;    
    private float speedMax = 120f;  
    private float speedMin = -120f;  
    private float speedUpA = 2f;   
    private float speedDownS = 4f; 
    private float speedTend = 0.5f; 
    private float speedBack = 1f; 

    // Update is called once per frame
    void Update()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (Input.GetKey(KeyCode.W) && speedOne < speedMax)
        {
            speedOne = speedOne + Time.deltaTime * speedUpA;
        }
        
        if (Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedDownS;
        }
    
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedTend;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne < 0f)
        {
            speedOne = speedOne + Time.deltaTime * speedTend;
        }

       
        if (Input.GetKey(KeyCode.S))
        {
            speedOne = speedOne - Time.deltaTime * speedBack;
        }

      
        if (Input.GetKey(KeyCode.Space) && speedOne != 0)
        {
            speedOne = Mathf.Lerp(speedOne, 0, 0.4f);
            if (speedOne < 5) speedOne = 0;
        }




        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);
       
        if (speedOne > 1f)
        {
            y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
            transform.Rotate(0, y, 0);
        }

      
    }

}
