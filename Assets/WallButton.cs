using UnityEngine;
using System.Collections;

public class WallButton : MonoBehaviour {

    public MainController Controller;
    public bool isButton = false;
    private float distance;
    private Rigidbody rdb;
    private BoxCollider bc;
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        rdb.mass = 500.0f;
    }
    void OnMouseDown()
    {
        bc.enabled = false;
        Controller.isWallButton = true;
        isButton = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        rdb.freezeRotation = true;
        
    }

    void OnMouseUp()
    {
        bc.enabled = true;
        Controller.isWallButton = false;
        isButton = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        rdb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        rdb.freezeRotation = false;
        
    }
    private Vector3 screenPoint;
    private Vector3 offset;
    void Update()
    {
        if(isButton)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, rayPoint.y, rayPoint.z);
            
        }
    }
}
