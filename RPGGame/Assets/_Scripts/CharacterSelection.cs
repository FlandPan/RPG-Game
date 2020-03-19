using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;

    public void SwitchBoy() {
        PlayerSingleton.player = boy;
        Destroy(girl);
        PlayerSingleton.ChosenType(boy);
        DontDestroyOnLoad(boy);
        boy.GetComponent<PlayerMovement>().SetEvent();
        this.gameObject.SetActive(false);
        CheckDuplicates();
    }

    public void SwitchGirl() {
        PlayerSingleton.player = girl;
        Destroy(boy);
        PlayerSingleton.ChosenType(girl);
        DontDestroyOnLoad(girl);
        girl.GetComponent<PlayerMovement>().SetEvent();
        this.gameObject.SetActive(false);
        CheckDuplicates();
    }
    
    public void CheckDuplicates(){
        GameObject[] dups = GameObject.FindGameObjectsWithTag("Player");
        if (dups.Length > 1){
            Destroy(dups[0]);
        }
    }
}
