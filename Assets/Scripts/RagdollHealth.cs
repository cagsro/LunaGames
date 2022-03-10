using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollHealth : MonoBehaviour
{
    public static RagdollHealth instance;
    public float currentHealth;
    public float startHealth=100f;
    
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
        currentHealth=startHealth;
        //Collider coll =GetComponent<Collider>();
        //coll.enabled=true;
        Invoke("invok",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Can degeri:   "+currentHealth);
        if (currentHealth<=0f)
        {
            Debug.Log("Player oldu");
            Destroy (gameObject);
            return;
        }
    }
    void invok()
    {
        Collider coll =GetComponent<Collider>();
        coll.enabled=true;
    }
}
