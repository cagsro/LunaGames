using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public static RagdollController instance;
    private Touch touch;
    public float speed=5f;
    public float speedModifier=0.01f;
    public float rlspeed;
    public Animator anim;
    public bool finishPad=false;
    public GameObject player;
    public Rigidbody rb;
    public float Torque;
    private void Awake()
    {        
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        rlspeed =5f;
        Physics(true);
        Collider(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.transform.position+=(Vector3.forward * (speed) * Time.deltaTime);
        rb.AddTorque(transform.up*Torque, ForceMode.Impulse);
        //this.transform.position+=(Vector3.forward * (speed) * Time.deltaTime);
        if(finishPad && speed>=0f)
        {
            speed-=0.05f;
        }

        /*if (Input.touchCount > 0) // Dokunma varsa;
        {
            touch = Input.GetTouch(0); // Degiskeni atama atama

            if (touch.phase == TouchPhase.Moved) // Dokunma basladiginda;
            {
                //Yeni koordinatlar bunlar olsun.
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z);
            }
        }*/

        if(Input.GetKey("a"))
        {
            player.transform.position+=(Vector3.left *rlspeed* Time.deltaTime);
            this.transform.position+=(Vector3.forward * 0.5f * Time.deltaTime);
        }
        if( Input.GetKey("d"))
        {
            player.transform.position+=(Vector3.right *rlspeed* Time.deltaTime);
            this.transform.position+=(Vector3.forward * 0.5f * Time.deltaTime);
        } 

    }
    public void Physics (bool value)
    {
        Rigidbody[] rb =GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody childrensPhysics in rb)
        {
            childrensPhysics.isKinematic=value;
        }
    }
    public void Collider (bool value)
    {
        Collider[] coll =GetComponentsInChildren<Collider>();
        foreach(Collider childrensColliders in coll)
        {
            childrensColliders.enabled=value;
        }
    }
}
