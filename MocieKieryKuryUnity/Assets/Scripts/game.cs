using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{

    [SerializeField]
    private GameObject chickenModel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerController GetPlayer()
    {
        return chickenModel.GetComponent<PlayerController>();
    }


}
