using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : Photon.MonoBehaviour {

    //private Vector3 networkPosition;
    //private Quaternion networkRotation;
    public GameObject RightHand;
    private Vector3 realPosition;
    private Quaternion realRotation;
    public Transform RcontrollerLocal;
    public Transform RcontrollerGlobal;

    // Use this for initialization
    void Start()
    {
        RcontrollerGlobal = GameObject.Find("RHand").transform;
        RcontrollerLocal = RcontrollerGlobal.Find("Touch_controller_R_luxury");
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
        if (stream.isWriting)
        {


            stream.SendNext(RcontrollerGlobal.position);
            stream.SendNext(RcontrollerGlobal.rotation);
            stream.SendNext(RcontrollerLocal.localPosition);
            stream.SendNext(RcontrollerLocal.localRotation);

        }
        else 
        {
           this.transform.position = (Vector3)stream.ReceiveNext();
           this.transform.rotation = (Quaternion)stream.ReceiveNext();
            RightHand.transform.position = (Vector3)stream.ReceiveNext();
            RightHand.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }



}
