using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHolo : MonoBehaviour {

    Joint myJoint;
    PhotonView grabbed;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void joinObject(GameObject tarObj)
    {
        print("Join  Called");
        myJoint = gameObject.AddComponent<FixedJoint>();
        myJoint.connectedBody = tarObj.GetComponent<Rigidbody>();
        grabbed = tarObj.GetComponent<PhotonView>();
        grabbed.RequestOwnership();
    }

    public void removeObject(GameObject tarObj)
    {
        print("Remove Called");
        myJoint.connectedBody = null;
        Destroy(myJoint);

        tarObj.GetComponent<Rigidbody>().AddForce(-transform.up);
    }
        
}
