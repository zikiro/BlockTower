using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour 
{
    public GameObject[] Walls;
	// Use this for initialization
	void Start () 
    {
        GameObject Pivot = GameObject.Find("Pivot");
        for (float y = 0.5f; y < 9.5f; y=y+2)
        {
            for (float x = 0; x < 3f; x++)
            {
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.transform.position = new Vector3(x, y, 0);
                wall.transform.localScale = new Vector3(1, 1, 3);
                wall.gameObject.tag = "Cube";
               
            }
        }
        for (float y = 1.5f; y < 10.5f; y=y+2)
        {
            for (float z = -1; z < 2f; z++)
            {
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.transform.position = new Vector3(1, y, z);
                wall.transform.localScale = new Vector3(1, 1, 3);
                wall.transform.Rotate(0.0f, 90.0f, 0.0f);
                wall.gameObject.tag = "Cube";
                
            }
        }
        Walls = GameObject.FindGameObjectsWithTag("Cube");
        foreach(GameObject Wall in Walls)
        {
            Wall.AddComponent<WallButton>();
            Wall.GetComponent<WallButton>().Controller = Pivot.GetComponent<MainController>();
            Wall.AddComponent<Rigidbody>();
        }
       

	}
}
