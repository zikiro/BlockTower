using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;



public class HoloBlock : MonoBehaviour, IInputHandler, IInputClickHandler
{
    public Material altMat;
    public Material defMat;

    Joint joint;

    bool selected = false;

    Renderer myRend;

    public GameObject hololens;
    Rigidbody myRigd;

    // Use this for initialization
    void Start()
    {
        myRend = GetComponent<Renderer>();
        myRigd = GetComponent<Rigidbody>();
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void tappedOn()
    {
        if (!selected)
        {
            selected = true;
            myRend.material = altMat;
            hololens.GetComponent<MyHolo>().joinObject(gameObject);
            //joint.connectedBody = hololens.GetComponent<Rigidbody>();
        }
        else
        {
            selected = false;
            myRend.material = defMat;
            hololens.GetComponent<MyHolo>().removeObject(gameObject);
            myRigd.AddForce(-Vector3.up);
            //myRigd.useGravity = false;
            //myRigd.useGravity = true;
            //joint.connectedBody = null;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        print("INPUT CLICKED!!");
        if (!selected)
        {
            selected = true;
            myRend.material = altMat;
            hololens.GetComponent<MyHolo>().joinObject(gameObject);
        }
        else
        {
            selected = false;
            myRend.material = defMat;
            hololens.GetComponent<MyHolo>().removeObject(gameObject);
        }
        
    }


    public void OnInputUp(InputEventData eventData)
    {
        //myRend.material = defMat;
        //print("Tap up registered");
    }

    public void OnInputDown(InputEventData eventData)
    {
        //myRend.material = altMat;
        //print("Tap down registered");
    }
}

