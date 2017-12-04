using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : Photon.MonoBehaviour {

    //private Vector3 networkPosition;
    //private Quaternion networkRotation;
    private Vector3 realPosition;
    private Quaternion realRotation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        


        //transform.position = Vector3.Lerp(transform.localPosition, realPosition, Time.deltaTime * 10);
        //transform.rotation = Quaternion.Lerp(transform.localRotation, realRotation, Time.deltaTime * 10);

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting == true)
        {


            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else 
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }



}
