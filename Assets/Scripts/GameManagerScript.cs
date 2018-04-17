using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManagerScript : Photon.MonoBehaviour
{
    //
    //Controls elements of the game such as end game conditions and resetting the game space
    //

    public int layers = 12;
    //List of all blocks in the scene
    public GameObject[] AllBlocks;

    public float ResetTimer = 5f;
    public bool gameOver = false;
    public int blocksGrounded = 0;
    public GameObject androidPlayer;
    public AndroidGrab grab;
    
    // Use this for initialization
    void Start ()
    {
      
    }
    void getAllBlocks()
    {
        AllBlocks = GameObject.FindGameObjectsWithTag("Block");
    }
    // Update is called once per frame
    void Update ()
    {
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("Mastah");
        }
        if (GameObject.Find("AndroidPlayer(Clone)").GetPhotonView().isMine && androidPlayer == null)
        {
            androidPlayer = GameObject.Find("AndroidPlayer(Clone)");
            grab = androidPlayer.GetComponent<AndroidGrab>();
        }
        getAllBlocks();
        if (AllBlocks.Length == 0)
        {
            AllBlocks = GameObject.FindGameObjectsWithTag("Block");
        }
        if(grab.blocks.Length == 0)
        {
            grab.blocks = GameObject.FindGameObjectsWithTag("Block");
        }

        if (blocksGrounded >= 5) { gameOver = true; }
        if (blocksGrounded < 5) { gameOver = false; }

        if (gameOver == true)
        {
            //PC Reset button
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                photonView.RPC("ResetAllBlocks", PhotonTargets.All, null);

            }
        }
        
	}

    //Resets blocks to the state they were when the scene starts
   
    public void ResetAllBlocks()
    {

        
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Block"))
            {

                Destroy(go);
                PhotonNetwork.Destroy(go);
            }

            Array.Clear(AllBlocks, 0, 0);


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

    public void groundedBlocksAdd()
    {
        blocksGrounded++;
    }
}
