using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainController : MonoBehaviour 
{
    public bool isWallButton = false;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    
    void Start()
    {
        Physics.gravity = new Vector3(0.0f, -20.0f, 0.0f);
        
    }
    void Update()
    {
        if(Input.GetMouseButton(0) && !isWallButton)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            //float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(0.0f, h, 0.0f);
            
            
           

        }
    }
}
