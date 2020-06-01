using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{

    public Text healthText;
    public Text distanceText;
    public Text BestScore;
    public Text distanceTextFinish;
    public Text BestScoreFinish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateHealth(int Health)
    {
        healthText.text = ("HEALTH: "+ Health);
    }

    public void UpdateDistance(float distance)
    {
        //distance.ToString("F2");
        distanceText.text = ("DISTANCE: " + distance.ToString("F1"));
        distanceTextFinish.text = ("YOUR DISTANCE: " + distance.ToString("F1"));
        BestScore.text = ("BEST: " + PlayerPrefs.GetFloat("HighScore").ToString("F1"));
        BestScoreFinish.text = ("BEST SCORE: " + PlayerPrefs.GetFloat("HighScore").ToString("F1"));
    }

}
