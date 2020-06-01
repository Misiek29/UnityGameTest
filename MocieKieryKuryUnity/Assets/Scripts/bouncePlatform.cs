using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePlatform : MonoBehaviour
{

    public float bounciness;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.rigidbody.AddForce(new Vector3(-collision.relativeVelocity.x, -collision.relativeVelocity.y, -collision.relativeVelocity.z) * bounciness, ForceMode.Impulse);
        }
     
    }
}
