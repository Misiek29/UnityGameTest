using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundMove : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3( (Player.transform.position.x * 0.5f), this.transform.position.y, this.transform.position.z);
    }
}
