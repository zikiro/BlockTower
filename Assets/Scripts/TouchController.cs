using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private Vector3 networkPosition;
    private Quaternion networkRotation;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TrackControllers();


    }

    void OnPhotonSerializeState(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting == true)
        {
            networkRotation = this.transform.rotation;
            networkPosition = this.transform.position;

            stream.SendNext(networkPosition);
            stream.SendNext(networkRotation);
        }
        else if (stream.isReading == true)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
    }

    void TrackControllers()
    {
        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
    }
}
