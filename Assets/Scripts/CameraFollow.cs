using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform target;
    public float smoothSpeed=0.125f;
    public Vector3 offset;

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition=target.position+offset;
        Vector3 smoothedPosition =Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position = smoothedPosition;
    }
    public void Rotate()
    {
       transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(45,0,0),smoothSpeed);
       offset.z=-2.5f;

    }
}
