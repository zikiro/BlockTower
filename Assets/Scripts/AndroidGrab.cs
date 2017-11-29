using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidGrab : MonoBehaviour
{
    private float speed = 0.005f, timeHeld = 0;

    private bool isGrabbed = false, rotated = false, moving = false;
    private GameObject selectedObject = null;
    public GameObject prevObject;

    private GameObject[] blocks = null;

    void getAllBlocks()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
    }
    private void Start()
    {
        getAllBlocks();
    }
    void Update()
    {
        if (selectedObject != null)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].GetComponent<Renderer>().material.color = Color.white;
                blocks[i].GetComponent<Rigidbody>().useGravity = true;
                blocks[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            selectedObject.GetComponent<Renderer>().material.color = Color.cyan;
            selectedObject.GetComponent<Rigidbody>().useGravity = false;
            selectedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
        //isGrabbed = false;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            //selectedObject.GetComponent<Rigidbody>().useGravity = false;
            selectedObject.GetComponent<Renderer>().material.color = Color.magenta;
            if (selectedObject == null)
            {
                return;
            }
            moving = true;
            float multiplier = 1;
            if (selectedObject.transform.rotation.y >= -1)
            {
                multiplier = -1;
            }
            else
            {
                multiplier = 1;
            }
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if (Mathf.Abs(touchDeltaPosition.y) > Mathf.Abs(touchDeltaPosition.x))
            {
                selectedObject.transform.Translate(0, touchDeltaPosition.y * speed, 0);
            }
            else
            {
                selectedObject.transform.Translate(0, 0, touchDeltaPosition.x * speed * multiplier);
            }

            // Move object across XY plane    
        }
        else
        {
            moving = false;
        }

        if (Input.touchCount > 0 /*&& !isGrabbed*/)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.tapCount == 2)
                {
                    getAllBlocks();

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Block")
                        {
                            selectedObject = hit.transform.gameObject;
                        }
                        else
                        {
                            selectedObject = null;
                            for (int i = 0; i < blocks.Length; i++)
                            {
                                blocks[i].GetComponent<Renderer>().material.color = Color.white;
                                blocks[i].GetComponent<Rigidbody>().useGravity = true;
                                blocks[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                            }
                        }
                    }
                }
                else if (touch.tapCount == 1)
                {
                    if (!moving)
                    {
                        timeHeld += Input.GetTouch(0).deltaTime;
                    }
                    if (timeHeld >= 1.0f)
                    {
                        if (selectedObject != null && !rotated)
                        {
                            if (selectedObject.transform.rotation.y == 0)
                            {
                                float yRotation = 90;
                                Vector3 selectedRotation = new Vector3(0, yRotation, 0);
                                selectedObject.transform.rotation = Quaternion.Euler(selectedRotation);
                            }
                            else
                            {
                                float yRotation = 0;
                                Vector3 selectedRotation = new Vector3(0, yRotation, 0);
                                selectedObject.transform.rotation = Quaternion.Euler(selectedRotation);
                            }
                            rotated = true;
                        }
                        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        {
                            timeHeld = 0;
                            rotated = false;
                        }
                    }
                }
            }
        }
    }
    public void Rotate()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
