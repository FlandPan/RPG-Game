using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score1;
    public Text score2;
    public Text score3;
    public int number;
    void Start(){
        score1.text = "High Score 1: " + PlayerPrefs.GetInt("HS1").ToString();
        score2.text = "High Score 2: " + PlayerPrefs.GetInt("HS2").ToString();
        score3.text = "High Score 3: " + PlayerPrefs.GetInt("HS3").ToString();
    }

    void Update(){        
        if (number > PlayerPrefs.GetInt("HS1")){
            PlayerPrefs.SetInt("HS3", PlayerPrefs.GetInt("HS2"));
            PlayerPrefs.SetInt("HS2", PlayerPrefs.GetInt("HS1"));
            PlayerPrefs.SetInt("HS1", number);
            score1.text = "High Score 1: " + PlayerPrefs.GetInt("HS1");
            score2.text = "High Score 2: " + PlayerPrefs.GetInt("HS2");
            score3.text = "High Score 3: " + PlayerPrefs.GetInt("HS3");
        } else if (number > PlayerPrefs.GetInt("HS2")){
            PlayerPrefs.SetInt("HS3", PlayerPrefs.GetInt("HS2"));
            PlayerPrefs.SetInt("HS2", number);
            score2.text = "High Score 2: " + PlayerPrefs.GetInt("HS2");
            score3.text = "High Score 3: " + PlayerPrefs.GetInt("HS3");
        } else if (number > PlayerPrefs.GetInt("HS3"))        {
            PlayerPrefs.SetInt("HS3", number);
            score3.text = "High Score 3: " + PlayerPrefs.GetInt("HS3");
        }
    }
    public static void updateNum(int num){
        if (BossHits.getHP() == 0)
        {
            number = num;
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
