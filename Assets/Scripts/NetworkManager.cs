using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NetworkManager : Photon.PunBehaviour {

    // Use this for initialization

    public bool PC = true;
    public bool Oculus = false;
    public bool LeapMotion = false;
    public bool Hololens = false;
    public bool ARCore = false;
    public bool Xbone = false;

    public int layers = 12;
	void Start ()
    {
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("Lime");
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
                for (float i = 0; i < 0.04; i = i + 0.02f)
                {
                    GameObject Layer = PhotonNetwork.Instantiate("JBlock", new Vector3(i, (0.02f + (col / 50f)), 0.02f), Quaternion.identity, 0);

                }
            }
            else
            {
                for (float i = 0; i < 0.04; i = i + 0.02f)
                {
                    GameObject Layer = PhotonNetwork.Instantiate("JBlock", new Vector3(0.02f, (0.02f + (col / 50f)), i), Quaternion.Euler(0, 90, 0), 0);

                }
            }

        }
    }

    public override void OnJoinedRoom()
    {
        
        base.OnJoinedRoom();

<<<<<<< HEAD
        if (PC)
        {

            GameObject Player = PhotonNetwork.Instantiate("playerprefab", new Vector3(0, .02f, -.08f), Quaternion.identity, 0);

            //Random color
            Color Rando = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Player.GetComponent<Renderer>().material.SetColor("_Color", Rando);
=======
        if (XRDevice.isPresent == true)
        {
          
                GameObject Player = PhotonNetwork.Instantiate("OVRPlayer", new Vector3(0f, 1.32f, -2.46f), Quaternion.identity, 0);
            
>>>>>>> aacf7e42f18511487ef8707c3b0ab443631838b5
        }

        else if (LeapMotion)
        {

            GameObject Player = PhotonNetwork.Instantiate("BasicVRPlayer", new Vector3(0, .02f, -.08f), Quaternion.identity, 0);

            //Random color
            Color Rando = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Player.GetComponent<Renderer>().material.SetColor("_Color", Rando);

        }
        
        else if(Oculus)
        {
            //Spawn Oculus Player
        }

        else if (Hololens)
        {
            //Spawn Hololens Player
        }

        else if (ARCore)
        {
            //Spawn ARCore Player
        }
        else if (Xbone)
        {
            GameObject Player = PhotonNetwork.Instantiate("Xboxplayerprefab", new Vector3(0, .1f, -.4f), Quaternion.identity, 0);

            //Random color
            Color Rando = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Player.GetComponent<Renderer>().material.SetColor("_Color", Rando);
        }



    }

    public void RestartScene()
    {
        PhotonNetwork.LoadLevel(0);
    }

    // Update is called once per frame
    void Update ()
    {
<<<<<<< HEAD
        
    }

=======
		//if(PhotonNetwork.connected == true)
  //      {
  //          gameObject.GetComponent<Camera>().enabled = false;
  //      }
	}
>>>>>>> aacf7e42f18511487ef8707c3b0ab443631838b5
}
