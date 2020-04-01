﻿using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score1;
    public Text score2;
    public Text score3;

    void Start(){
        score1.text = "High Score 1: " + PlayerPrefs.GetInt("HS1").ToString();
        score2.text = "High Score 2: " + PlayerPrefs.GetInt("HS2").ToString();
        score3.text = "High Score 3: " + PlayerPrefs.GetInt("HS3").ToString();
    }

    public void UpdateScore(){
        int number = Random.Range(1,7);
        
        if (number > PlayerPrefs.GetInt("HS1")){
            PlayerPrefs.SetInt("HS1", number);
            score1.text = "High Score 1: " + number.ToString();
        } else if (number > PlayerPrefs.GetInt("HS2")){
            PlayerPrefs.SetInt("HS2", number);
            score2.text = "High Score 2: " + number.ToString();
        } else if (number > PlayerPrefs.GetInt("HS3"))
        {
            PlayerPrefs.SetInt("HS3", number);
            score3.text = "High Score 3: " + number.ToString();
        }
    }

    public void ResetScores(){
        PlayerPrefs.DeleteKey("HS1");
        score1.text = "High Score 1: 0";
        PlayerPrefs.DeleteKey("HS2");
        score2.text = "High Score 2: 0";
        PlayerPrefs.DeleteKey("HS3");
        score3.text = "High Score 3: 0";
    }
}
