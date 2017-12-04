using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class HoloBlock : MonoBehaviour, IInputHandler, IInputClickHandler, ISpeechHandler
{
    private Material cachedMaterial;

    public Material altMat;
    public Material defMat;

    Joint joint;

    bool selected = false;

    Renderer myRend;

    public GameObject hololens;
    Rigidbody myRigd;

    // Use this for initialization
    void Start()
    {
        myRend = GetComponent<Renderer>();
        myRigd = GetComponent<Rigidbody>();
        joint = GetComponent<FixedJoint>();
        hololens = (hololens != null ? hololens : GameObject.FindGameObjectWithTag("Hololens"));
        cachedMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        OnSelect();
        //if (!selected)
        //{
        //    selected = true;
        //    myRend.material = altMat;
        //    hololens.GetComponent<MyHolo>().joinObject(gameObject);
        //}
        //else
        //{
        //    selected = false;
        //    myRend.material = defMat;
        //    hololens.GetComponent<MyHolo>().removeObject(gameObject);
        //}
    }

    public void OnSelect()
    {
        if (!selected)
        {
            selected = true;
            myRend.material = altMat;
            hololens.GetComponent<MyHolo>().joinObject(gameObject);
        }
        else
        {
            selected = false;
            myRend.material = defMat;
            hololens.GetComponent<MyHolo>().removeObject(gameObject);
        }
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch(eventData.RecognizedText.ToLower())
        {
            case "vertical":
                myRend.material.SetColor("_Color", Color.red);
                //Move the block vertically
                break;
            case "horizontal":
                myRend.material.SetColor("_Color", Color.blue);
                //Move the block on the x and z
                break;
            case "grab":
                OnSelect();
                break;
            case "select":
                OnSelect();
                break;


        }
    }


    public void OnInputUp(InputEventData eventData)
    {
        //myRend.material = defMat;
        //print("Tap up registered");
    }

    public void OnInputDown(InputEventData eventData)
    {
        //myRend.material = altMat;
        //print("Tap down registered");
    }
}

