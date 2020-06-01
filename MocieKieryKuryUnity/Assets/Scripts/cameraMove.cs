using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position  + offset;
        Vector3 smootPosition = Vector3.Lerp(transform.position, targetPosition, smoothPower);
        transform.position = smootPosition;

        //transform.LookAt(target);
    }
}
