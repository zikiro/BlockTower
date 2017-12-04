using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidCamRotate : MonoBehaviour
{

    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    //Simple mouse based Camera controls
    void LateUpdate()
    {
        if (Input.touchCount > 1)
        {
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.transform.Rotate(0, horizontal, 0);

            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = target.transform.position - (rotation * offset);

            transform.LookAt(target.transform);
        }
    }
}
