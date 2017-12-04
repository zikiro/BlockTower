using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour {

    public GameObject rightHand;
    public GameObject leftHand;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PhotonView pv = PhotonView.Get(this);
		
            if (PhotonNetwork.connected == true && pv.isMine == true)
            {
            rightHand.gameObject.SetActive(true);
            leftHand.gameObject.SetActive(true);
            }
        
	}
}
