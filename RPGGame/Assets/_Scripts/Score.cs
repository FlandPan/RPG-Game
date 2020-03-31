using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;

    public void UpdateScore(){
        int number = Random.Range(1,7);
        score.text = "High Score 1: " + number.ToString();

        PlayerPrefs.SetInt("HS1", number);
    }
}
