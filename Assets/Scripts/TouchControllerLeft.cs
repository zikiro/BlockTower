using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerLeft : Photon.MonoBehaviour {

    private Vector3 networkPosition;
    private Quaternion networkRotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        networkPosition = transform.localPosition;
        networkRotation = transform.localRotation;
        
    }

    void OnPhotonSerializeState(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting == true)
        {
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
        }
        else
        {
            networkPosition = (Vector3)stream.ReceiveNext();
            networkRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
