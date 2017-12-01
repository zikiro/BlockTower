using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour {

    public GameObject[] objects;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PhotonView pv = PhotonView.Get(this);
		foreach(GameObject go in objects)
        {
            if (PhotonNetwork.connected == true && pv.isMine == true)
            {
                go.SetActive(true);
            }
        }
	}
}
