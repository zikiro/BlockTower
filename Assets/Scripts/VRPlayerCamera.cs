using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerCamera : Photon.PunBehaviour {

	// Use this for initialization
	void Start ()
    {
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        PhotonView pv = PhotonView.Get(this);
        if (pv.isMine == true && PhotonNetwork.connected == true)
        {
            GameObject.Find("vrPlayer/CenterEyeAnchor").GetComponent<Camera>().enabled = false;
        }
    }
}
