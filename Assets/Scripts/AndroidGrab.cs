using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidGrab : MonoBehaviour
{
    public float speed = 0.001F;

    private bool isGrabbed = false;
    private GameObject selectedObject = null;
    private GameObject prevObject = null;

    private GameObject[] blocks = null;

    void getAllBlocks()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
    }
    void Update()
    {
        if (selectedObject != null)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].GetComponent<Renderer>().material.color = Color.white;
                selectedObject.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<Rigidbody>().useGravity = false;
                    prevObject.GetComponent<Rigidbody>().useGravity = true;
                    // Get movement of the finger since last frame
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                    // Move object across XY plane
                    selectedObject.transform.Translate(touchDeltaPosition.x * speed, 0, touchDeltaPosition.y * speed);
                }
            }

        }
        if (Input.touchCount > 0) // && Input.GetTouch(0).phase == TouchPhase.Moved
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.tapCount > 1)
                {
                    getAllBlocks();

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Block" && prevObject != hit.transform.gameObject)
                        {
                            selectedObject = hit.transform.gameObject;
                            
                        }
                    }
                    else
                    {
                        selectedObject = null;
                    }
                }
                else
                {
                    
                    
                }
            }
            
        }
        else
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].GetComponent<Rigidbody>().useGravity = true;
            }
        }

    }
}
