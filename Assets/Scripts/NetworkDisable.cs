using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkDisable : Photon.MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!photonView.isMine)
        {
            gameObject.GetComponent<Camera>().enabled = false;
        }
	}
}
