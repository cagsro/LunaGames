using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public Material currentColor;
    public float Health;
    public float damage;
    public float lerp;
    public float lerpValue;
    public Color red;
    public Color blue;
    // Start is called before the first frame update
    void Start()
    {
        red=Color.red;
        blue=Color.blue;
        lerpValue=damage/Health;
    }

    // Update is called once per frame
    void Update()
    {
        currentColor.color = Color.Lerp(blue,red,lerp);
    }
    void OnCollisionEnter (Collision other)
        {
            if(other.transform.tag == "tree")
            {
                Debug.Log("carpti");
                RagdollHealth.instance.TakeDamage(damage);
                lerp+=lerpValue;
                if(lerp>=1f)
                {
                    lerpValue=0f;
                    damage=0f;
                }
            }
            if(other.transform.tag == "finishPoint")
            {
                Debug.Log("finishPoint");
                RagdollController.instance.finishPad=true;
            }
        }
        void OnTriggerEnter (Collider other)
        {
            
            if(other.transform.tag == "startPoint")
            {
                Debug.Log("startPoint");
                RagdollController.instance.Physics(false);
                RagdollController.instance.Collider(true);
                RagdollController.instance.speed=2f;
                //Invoke("Camera",2f);
                RagdollController.instance.anim.enabled=false;  
            }
            
        }
        void Camera()
        {
            CameraFollow.instance.Rotate();
        }
}
