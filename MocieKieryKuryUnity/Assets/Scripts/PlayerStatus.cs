using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int Health;
    public int StartPointHealt;

    public float distance;

    public int platforms;
    private UIControll UIController;
    private GameObject Player;

    public GameObject LastPlatform;
    public string HighScore;

    public Transform startPoint;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.transform;

        UIController = FindObjectOfType<UIControll>();
        
        Health = StartPointHealt;
        UpdateStats();
       // this.gameObject.transform.position = startPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = (startPoint.position.x - player.position.x);

        if(distance < 0 )
        {
            distance = distance * -1;
        }

        UpdateDistance();
        
    }

   public void damage()
    {
        Health = Health - 1;

    }

   public void UpdateStats()
    {
        UIController.UpdateHealth(Health);
    }

    public void UpdateDistance()
    {
        UIController.UpdateDistance(distance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "fallPlatform" || collision.gameObject.tag == "BouncePlatform") 
        {
   
            LastPlatform = collision.gameObject;
        }
      
        


    }



}
