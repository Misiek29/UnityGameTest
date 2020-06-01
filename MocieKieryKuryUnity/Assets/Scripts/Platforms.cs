using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.tag == "Player")
    //    {
    //        rb.isKinematic = false;
    //        rb.AddForce(Vector3.up, ForceMode.);
    //    }
        
    //}
}
