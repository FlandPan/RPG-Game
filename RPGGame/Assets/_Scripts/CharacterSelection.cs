using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;

    public void switchBoy() {
        PlayerSingleton.player = boy;
        Destroy(girl);
        PlayerSingleton.ChosenType(boy);
        this.gameObject.SetActive(false);
    }

    public void switchGirl() {
        PlayerSingleton.player = girl;
        Destroy(boy);
        PlayerSingleton.ChosenType(girl);
        this.gameObject.SetActive(false);
    }
}
