using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerLeft : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);

        
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting == true)
        {
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
        }
        else
        {
            transform.localPosition = (Vector3)stream.ReceiveNext();
            transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
