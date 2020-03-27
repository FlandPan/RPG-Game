using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;

    void Start()
    {
        CheckDuplicates(2);
    }
    public void SwitchBoy() {
        PlayerSingleton.player = boy;
        Destroy(girl);
        PlayerSingleton.ChosenType(boy);
        DontDestroyOnLoad(boy);
        this.gameObject.SetActive(false);
        CheckDuplicates(1);
    }

    public void SwitchGirl() {
        PlayerSingleton.player = girl;
        Destroy(boy);
        PlayerSingleton.ChosenType(girl);
        DontDestroyOnLoad(girl);
        this.gameObject.SetActive(false);
        CheckDuplicates(1);
    }
    
    public void CheckDuplicates(int length){
        GameObject[] dups = GameObject.FindGameObjectsWithTag("Player");
        if (dups.Length > length){
            Destroy(dups[0]);
        }
    }
}
