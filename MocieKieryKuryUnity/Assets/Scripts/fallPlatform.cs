using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour
{


    Rigidbody rb;
    Renderer render;

    Color fallColor;

    public float fallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        render = this.GetComponent<Renderer>();
       
        fallColor.r = 0.8207547f;
        fallColor.g = 0.4142488f;
        fallColor.b = 0.4142488f;
        fallColor.a = 1;



    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("obnizam");
            rb.velocity = new Vector3(0, fallSpeed, 0);


            



        }
    }

    private void OnJointBreak(float breakForce)
    {
        Renderer rand = GetComponent<Renderer>();
        rand.material.SetColor("_Color", fallColor);

    }
}
