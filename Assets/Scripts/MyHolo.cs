using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHolo : MonoBehaviour {

    Joint myJoint;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void joinObject(GameObject tarObj)
    {
        
        myJoint = gameObject.AddComponent<FixedJoint>();
        myJoint.connectedBody = tarObj.GetComponent<Rigidbody>();
    }

    public void removeObject(GameObject tarObj)
    {
        
        myJoint.connectedBody = null;
        Destroy(myJoint);

        tarObj.GetComponent<Rigidbody>().AddForce(-transform.up);
    }
        
}
