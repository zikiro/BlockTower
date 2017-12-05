using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NetworkManager : Photon.PunBehaviour {

    // Use this for initialization
    public GameObject Player;
    public int layers = 12;
	void Start ()
    {

        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.25");
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

        Debug.Log("OnCreatedRoom() : You Have Created a Room : " + PhotonNetwork.room.Name);
        for (int col = 0; col < layers; col++)
        {
            if (((col / 2) * 2) == col)
            {
                for (float i = 0; i < 0.15; i = i + 0.05f)
                {
                    GameObject Layer = PhotonNetwork.Instantiate("JBlock", new Vector3(i, (0.05f + (col / 20f)), 0.05f), Quaternion.identity, 0);

                }
            }
            else
            {
                for (float i = 0; i < 0.15; i = i + 0.05f)
                {
                    GameObject Layer = PhotonNetwork.Instantiate("JBlock", new Vector3(0.05f, (0.05f + (col / 20f)), i), Quaternion.Euler(0, 90, 0), 0);

                }
            }

        }
    }

    public override void OnJoinedRoom()
    {

        base.OnJoinedRoom();



        if (XRDevice.isPresent == true)
        {

                //GameObject Player = PhotonNetwork.Instantiate("BasicVRPlayer", new Vector3(0f, 1.0f, -5.9f), Quaternion.identity, 0);

        }
        else
        {

            //GameObject Player = PhotonNetwork.Instantiate("playerprefab", new Vector3(0, .02f, -.08f), Quaternion.identity, 0);

        }
        Color Rando = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Player.GetComponent<Renderer>().material.SetColor("_Color",Rando);
        


    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
