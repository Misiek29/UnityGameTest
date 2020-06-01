using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    private GameObject Player;
    public GameObject startPoint;
    float PlayerHaightPosition;
    public GameObject GameOverScreen;
    

    public Transform respawnPosition;

    private PlayerStatus PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
        PlayerStats = FindObjectOfType<PlayerStatus>();
      
        Player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(Player.transform.position.x, -10, Player.transform.position.z);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStats.damage();
            PlayerStats.UpdateStats();

            if (PlayerStats.Health > 0)
            {

                other.transform.position = PlayerStats.LastPlatform.transform.position + Vector3.up * 2;
                Debug.Log(PlayerStats.LastPlatform.transform.position);
                Renderer rand = PlayerStats.LastPlatform.GetComponent<Renderer>();
                rand.material.SetColor("_Color", Color.white);


            }
            else
            {
                if (PlayerStats.distance > PlayerPrefs.GetFloat("HighScore"))
                {
                    PlayerPrefs.SetFloat("HighScore", PlayerStats.distance);
                }

                FinishGame();
            }
        }
        
    }

    public void FinishGame()
    {
       
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
       

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
       
    }

   



}
