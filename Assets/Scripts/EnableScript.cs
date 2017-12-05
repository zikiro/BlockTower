using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour {

   
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
            GameObject.Find("LoPoly_Rigged_Hand_Right").SetActive(true);
            GameObject.Find("LoPoly_Rigged_Hand_Left").SetActive(true);
            }
        
	}
}
