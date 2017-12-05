using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrMovement : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            transform.Translate(Vector3.up * Time.deltaTime*speed);
            Debug.Log("AAA");
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            Debug.Log("AAA");
        }
    }
}
