using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour {

    public GameObject vrPlayer;
    [SerializeField]
    private GameObject vrCam;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PhotonView pv = PhotonView.Get(this);
        if (PhotonNetwork.connected == true && pv.isMine == true)
            vrCam = vrPlayer.transform.Find("TrackingSpace/CenterEyeAnchor").gameObject;
        vrCam.GetComponent<Camera>().enabled = false;
	}
}
