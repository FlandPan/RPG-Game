using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    public int SceneNumber;
    public string Location;
    private UIManager _UI;

    void Awake()
    {
        _UI = GameObject.Find("UI").GetComponent<UIManager>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            _UI.Display(Location);
            if (Input.GetKeyDown(KeyCode.E)){
                SceneManager.LoadScene(SceneNumber);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            _UI.DisplayExit();
        }
    }
}
