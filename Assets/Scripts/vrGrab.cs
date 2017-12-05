using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrGrab : MonoBehaviour {

    public string ButtonName;
    public OVRInput.Controller controller;
    public GameObject grabbedObject;
    public bool grabbing = false;
    public Collider grabbedCol;
    public FixedJoint grabJoint;
    RigidbodyConstraints grabConst;
    Rigidbody myRb;
    Rigidbody goRb;
    public float mySpeed = 5f;
    public Material OGMat;

    //Needs to be set in Editor
    public Material grabMat;

    public PhotonView myView;
    public PhotonView grabView;


    // Use this for initialization
    void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody>();
        myView = gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myView.isMine)
        {

            


            //Sets the Grabbed objects Rigidbody properties
            if (grabbing == true)
            {
                myRb.constraints = RigidbodyConstraints.FreezeRotation;
                if (grabbedObject)
                {
                    goRb = grabbedObject.GetComponent<Rigidbody>();
                    goRb.useGravity = false;
                    goRb.constraints = RigidbodyConstraints.FreezeRotation;
                }
            }

            //Simple rotation
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (grabbedObject)
                {
                    grabbedObject.transform.Rotate(0, 90, 0);
                }
            }

            //Grab
            if (Input.GetAxis(ButtonName)==1)
            {
                //CreateJoint(RayForward());
                CreateJoint(RayCardinal());
            }

            //Release
            if (Input.GetAxis(ButtonName)<1)
            {
                ReleaseJoint();
            }

        }
    }

  


    GameObject RayForward()
    {
        //Raycast Forward
        RaycastHit[] fHits;
        fHits = Physics.RaycastAll(transform.position, gameObject.transform.forward);

        //Find Closest object hit
        if (fHits != null)
        {
            grabbing = true;
            if (fHits.Length > 0)
            {
                int closestHit = 0;

                for (int i = 0; i > fHits.Length; i++)
                {
                    if (fHits[i].distance < fHits[closestHit].distance)
                        closestHit = i;
                }

                //returns GameObject hit
                return fHits[closestHit].collider.gameObject;
            }
        }

        //If no object is hit returns null
        return null;
    }

    //Creates a joint with the GameObject passed into the function
    void CreateJoint(GameObject jointObj)
    {
        grabbedObject = jointObj;

        if (grabbedObject != null)
        {
            //Saves grabbed object Material and Sets a new one while grabbed
            OGMat = grabbedObject.GetComponent<Renderer>().material;
            grabbedObject.GetComponent<Renderer>().material = grabMat;

            //Networking?
            grabView = grabbedObject.GetComponent<PhotonView>();
            grabView.RequestOwnership();

            //Adds Joint componenet
            grabJoint = gameObject.AddComponent<FixedJoint>();
            grabJoint.connectedBody = grabbedObject.GetComponent<Rigidbody>();
        }
    }

    //Releases all joints and deletes them
    void ReleaseJoint()
    {
        if (grabbedObject)
        {
            grabbing = false;

            myRb.constraints = RigidbodyConstraints.FreezeRotation;
            goRb.constraints = RigidbodyConstraints.None;
            goRb.useGravity = true;


            //Get all joints attached to object
            FixedJoint[] allJoints;
            allJoints = gameObject.GetComponents<FixedJoint>();

            //Set the properties for all Rigidbodies attached to the joints
            foreach (FixedJoint curJ in allJoints)
            {
                Rigidbody curRb = curJ.connectedBody.GetComponent<Rigidbody>();
                curRb.constraints = RigidbodyConstraints.None;
                curRb.useGravity = true;
                curRb.AddForce(-transform.up);
            }

            //Delete all attached joints
            foreach (FixedJoint curJ in allJoints)
            {
                Destroy(curJ);
            }



            //Fixes a bug where gravity would be on but not applied.
            goRb.AddForce(-transform.up);

            //Set Material of object to it's original Material
            grabbedObject.GetComponent<Renderer>().material = OGMat;

            Destroy(grabJoint);
            grabbedCol = null;
            grabbedObject = null;
        }
    }


    GameObject RayCardinal()
    {

        //
        //Raycasts in cardinal directions
        //
        RaycastHit[] fHits;
        fHits = Physics.RaycastAll(transform.position, gameObject.transform.forward);
        Debug.DrawRay(transform.position, gameObject.transform.forward);

        RaycastHit[] bHits;
        bHits = Physics.RaycastAll(transform.position, -gameObject.transform.forward);
        Debug.DrawRay(transform.position, -gameObject.transform.forward);

        RaycastHit[] rHits;
        rHits = Physics.RaycastAll(transform.position, gameObject.transform.right);
        Debug.DrawRay(transform.position, gameObject.transform.right);

        RaycastHit[] lHits;
        lHits = Physics.RaycastAll(transform.position, -gameObject.transform.right);
        Debug.DrawRay(transform.position, -gameObject.transform.right);
        //
        //Raycasts in cardinal directions
        //



        //Forward Raycast check
        if (fHits != null)
        {
            grabbing = true;

            if (fHits.Length > 0)
            {
                int closestHit = 0;

                for (int i = 0; i > fHits.Length; i++)
                {
                    if (fHits[i].distance < fHits[closestHit].distance)
                        closestHit = i;
                }

                return fHits[closestHit].collider.gameObject;
            }
        }

        //Backwards Raycast check
        if (bHits != null)
        {
            grabbing = true;

            if (bHits.Length > 0)
            {
                int closestHit = 0;

                for (int i = 0; i > bHits.Length; i++)
                {
                    if (bHits[i].distance < bHits[closestHit].distance)
                        closestHit = i;
                }

                return bHits[closestHit].collider.gameObject;
            }
        }

        //Right Raycast check
        if (rHits != null)
        {
            grabbing = true;

            if (rHits.Length > 0)
            {
                int closestHit = 0;

                for (int i = 0; i > rHits.Length; i++)
                {
                    if (rHits[i].distance < rHits[closestHit].distance)
                        closestHit = i;
                }

                return rHits[closestHit].collider.gameObject;
            }
        }

        //Left Raycast check
        if (lHits != null)
        {
            grabbing = true;

            if (lHits.Length > 0)
            {
                int closestHit = 0;

                for (int i = 0; i > lHits.Length; i++)
                {
                    if (lHits[i].distance < lHits[closestHit].distance)
                        closestHit = i;
                }

                return lHits[closestHit].collider.gameObject;
            }
        }

        //Returns null if no GameObjects are found
        return null;
    }

}
