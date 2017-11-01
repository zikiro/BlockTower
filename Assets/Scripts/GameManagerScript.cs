using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //
    //Controls elements of the game such as end game conditions and resetting the game space
    //


    //List of all blocks in the scene
    public List<GameObject> AllBlocks = new List<GameObject>();

    public float ResetTimer = 5f;
    public bool gameOver = false;
    public int blocksGrounded = 0;
    
    // Use this for initialization
    void Start ()
    {
        //Finds all blocks in the scene using a tag
        foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block"))
        {
            AllBlocks.Add(block);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (blocksGrounded >= 5) { gameOver = true; }
        if (blocksGrounded < 5) { gameOver = false; }

        if (gameOver == true)
        {
            //PC Reset button
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                ResetAllBlocks();

            }
        }
        
	}

    //Resets blocks to the state they were when the scene starts
    public void ResetAllBlocks()
    {        
        foreach (GameObject block in AllBlocks)
        {            
            block.GetComponent<Blocks>().ResetBlock();
        }
        blocksGrounded = 0;
    }

    public void groundedBlocksAdd()
    {
        blocksGrounded++;
    }
}
