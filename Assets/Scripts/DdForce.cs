using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdForce : MonoBehaviour
{
    public Rigidbody rb;
    public float Torque;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(Torque, 0, 0);
        //transform.Rotate(Vector3.right, Torque * Time.deltaTime);
    }
}
