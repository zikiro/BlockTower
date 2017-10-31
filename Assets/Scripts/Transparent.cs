using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour {

    public MeshRenderer myMR;
    public Color myCO;
    public bool isTransparent = false;
    public float TransP = 0.1f;
    public List<Camera> allCams;
    public Shader myShader;
    public Shader TPShader;

    // Use this for initialization
    void Start ()
    {
        allCams = new List<Camera>();
        UpdateCameras();


        //isTransparent = true; // testing purposes
        setTransparency(TransP);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(allCams != null)
        {
            foreach(Camera cams in allCams)
            {
                RaycastHit hit;
                Physics.Raycast(cams.transform.position, gameObject.transform.position, out hit);
                if(hit.collider != gameObject.GetComponent<BoxCollider>())
                {
                    myMR.material.shader = TPShader;
                    isTransparent = true;
                    setTransparency(TransP);
                }
                else
                {
                    myMR.material.shader = myShader;
                    isTransparent = false;
                }

                                
            }
        }
	}

    public void setTransparency(float TP)
    {
        myMR = gameObject.GetComponent<MeshRenderer>();
        myCO = myMR.material.color;
        if (isTransparent == true)
        {
            myCO.a = TP;
            myMR.material.color = myCO;
        }
    }

    public void UpdateCameras()
    {
        foreach (Camera cam in FindObjectsOfType<Camera>())
        {
            allCams.Add(cam);
        }
    }
}
