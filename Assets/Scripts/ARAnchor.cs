using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARAnchor : MonoBehaviour
{
    public GameObject Floor;
    private GameObject[] blocks = null;

    void getAllBlocks()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
    }
    private void Start()
    {
        getAllBlocks();
        //var floorAnchor = Session.CreateAnchor(Floor.transform.position, Floor.transform.rotation);
        //Floor.transform.SetParent(floorAnchor.transform);
        for (int i = 0; i < blocks.Length; i++)
        {
            //var anchor = Session.CreateAnchor(blocks[i].transform.position, blocks[i].transform.rotation);
            //blocks[i].transform.SetParent(anchor.transform);
        }
    }
}