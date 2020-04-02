using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text s1;
    public Text s2;
    public Text s3;
    public static int score;

    void Start()
    {
        s1.text = "High Score 1: " + PlayerPrefs.GetInt("HS1").ToString();
        s2.text = "High Score 2: " + PlayerPrefs.GetInt("HS2").ToString();
        s3.text = "High Score 3: " + PlayerPrefs.GetInt("HS3").ToString();
    }
    public static void SetScore(int num)
    {
        score = num;
    }
    public static void updateNum()
    {
        if (score > PlayerPrefs.GetInt("HS1"))
        {
            PlayerPrefs.SetInt("HS3", PlayerPrefs.GetInt("HS2"));
            PlayerPrefs.SetInt("HS2", PlayerPrefs.GetInt("HS1"));
            PlayerPrefs.SetInt("HS1", score);
        }
        else if (score > PlayerPrefs.GetInt("HS2"))
        {
            PlayerPrefs.SetInt("HS3", PlayerPrefs.GetInt("HS2"));
            PlayerPrefs.SetInt("HS2", score);
        }
        else if (score > PlayerPrefs.GetInt("HS3"))
        {
            PlayerPrefs.SetInt("HS3", score);
        }
    }

    public void ResetScores()
    {
        PlayerPrefs.DeleteKey("HS1");
        PlayerPrefs.DeleteKey("HS2");
        PlayerPrefs.DeleteKey("HS3");
    }
}
