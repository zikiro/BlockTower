using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NetworkManager : Photon.PunBehaviour {

    // Use this for initialization
    public GameObject Player;

	void Start ()
    {

        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.1");
        PhotonNetwork.automaticallySyncScene = true;
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom() : You Have Created a Room : " + PhotonNetwork.room.name);
        for (int i = 0; i < 3; i++)
        {
            GameObject Tower = PhotonNetwork.Instantiate("JBlock", new Vector3(0+(i*2), 0+1, 0), Quaternion.identity, 0);
            GameObject Tower2 = PhotonNetwork.Instantiate("JBlock", new Vector3(0 + (i * 2), i + 1, 0), Quaternion.identity, 0);
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        base.OnJoinedRoom();
        if (XRDevice.isPresent == true)
        {
            GameObject Player = PhotonNetwork.Instantiate("VRplayerprefab", new Vector3(0.96f, 1.2f, -6.03f), Quaternion.identity, 0);
        }
        else
        {
            GameObject Player = PhotonNetwork.Instantiate("playerprefab", new Vector3(0, 1.88f, -4.37f), Quaternion.identity, 0);
        }
        Color Rando = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Player.GetComponent<Renderer>().material.SetColor("_Color",Rando);
        


    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
