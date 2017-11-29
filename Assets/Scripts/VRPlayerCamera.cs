using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerCamera : Photon.MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (photonView.isMine)
        {
            gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
