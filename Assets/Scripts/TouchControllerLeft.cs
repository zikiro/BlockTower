using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerLeft : Photon.MonoBehaviour
{



    //private Vector3 networkPosition;
    //private Quaternion networkRotation;
    public GameObject LeftHand;
    private Vector3 realPosition;
    private Quaternion realRotation;
    public Transform LcontrollerLocal;
    public Transform LcontrollerGlobal;

    // Use this for initialization
    void Start()
    {
        LcontrollerGlobal = GameObject.Find("LHand").transform;
        LcontrollerLocal = LcontrollerGlobal.Find("Touch_controller_L_luxury");
    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);



        //transform.position = Vector3.Lerp(transform.localPosition, realPosition, Time.deltaTime * 10);
        //transform.rotation = Quaternion.Lerp(transform.localRotation, realRotation, Time.deltaTime * 10);

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {


            stream.SendNext(LcontrollerGlobal.position);
            stream.SendNext(LcontrollerGlobal.rotation);
            stream.SendNext(LcontrollerLocal.localPosition);
            stream.SendNext(LcontrollerLocal.localRotation);

        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            LeftHand.transform.position = (Vector3)stream.ReceiveNext();
            LeftHand.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
