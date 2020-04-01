using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;
    private static GameObject _selected;
    private static bool _display = true;
    void Awake()
    {
        if (_display){
            _display = false;
        }
        else{
            this.gameObject.SetActive(false);
        }
        if (_selected != null){
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                if (player != _selected){
                    Destroy(player);
                }
            }
            _selected.transform.position = new Vector2(0,0);
        }
    }
    public static void SetDisplay(){
        _display = true;
    }
    public void SwitchBoy() {
        PlayerSingleton.player = boy;
        Destroy(girl);
        PlayerSingleton.ChosenType(boy);
        _selected = boy;
        DontDestroyOnLoad(boy);
        this.gameObject.SetActive(false);
        CheckDuplicates(1);
    }

    public void SwitchGirl() {
        PlayerSingleton.player = girl;
        Destroy(boy);
        _selected = girl;
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
