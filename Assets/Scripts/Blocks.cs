using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    //
    // Controls individual block properties with public functions that can be called by other Scripts
    //

    public Rigidbody MyRB;
    public Vector3 StartPosition;
    public Quaternion StartRotation;
    public float groundedHeight = .5f;
    public bool grounded = false;

    // Use this for initialization
    void Start ()
    {
        MyRB = GetComponent<Rigidbody>();
        StartPosition = gameObject.transform.position;
        StartRotation = gameObject.transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Only triggers when blocks are in motion
		if(MyRB.IsSleeping() == false)
        {
            if (grounded == false)
            {              
                if (isGrounded())
                {
                    //Lets the GameManager know that a block has hit the ground
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().groundedBlocksAdd();
                }
            }
        }
	}

    //Resets Block position, rotation
    public void ResetBlock()
    {        
        MyRB.velocity = new Vector3(0, 0, 0);
        MyRB.Sleep();
        gameObject.transform.position = StartPosition;
        gameObject.transform.rotation = StartRotation;
        grounded = false;
    }

    //Returns true if block is lower than the groundedHeight
    public bool isGrounded()
    {
        if(gameObject.transform.position.y < groundedHeight)
        {
            grounded = true;
            return true;
        }

        return false;
    }
}
