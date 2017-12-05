using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrGrab : MonoBehaviour {

    // Use this for initialization
    private GameObject grabbedObject;
    private bool grabbing;
    public float grabRadius;
    public LayerMask grabMask;
    public OVRInput.Controller controller;
    public string ButtonName;

    // Update is called once per frame
    void Update()
    {
        if (!grabbing && Input.GetAxis(ButtonName) == 1)
        {
            //Debug.Log(Time.time);
            GrabObject();
        }
        if (grabbing && Input.GetAxis(ButtonName) < 1)
        {
            //Debug.Log(Time.time);
            DropObject();
        }
    }

    void GrabObject()
    {
        grabbing = true;
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);

        if (hits.Length > 0)
        {
            int closestHit = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance > hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }
            grabbedObject = hits[closestHit].transform.gameObject;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

            grabbedObject.transform.parent = transform;
        }
    }

    void DropObject()
    {
        grabbing = false;
        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;

            grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
            grabbedObject.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(controller);

            grabbedObject = null;
        }
    }
}
