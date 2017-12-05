using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrPlayerMovement : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Movee");
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
	}
}
