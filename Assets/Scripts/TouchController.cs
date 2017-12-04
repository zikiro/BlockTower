using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private Vector3 networkPosition;
    private Quaternion networkRotation;
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

        realRotation = transform.rotation;
        realPosition = transform.position;
    }

    void OnPhotonSerializeState(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            networkRotation = this.transform.rotation;
            networkPosition = this.transform.position;

            stream.Serialize(ref networkPosition);
            stream.Serialize(ref networkRotation);
        }
        else if (stream.isReading)
        {
            stream.Serialize(ref realRotation);
            stream.Serialize(ref realPosition);
        }
    }

 
}
