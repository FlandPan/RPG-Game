using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private Scene currentSceneIndex;

    void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene();
    }
    public void loadNextLevel(int nextLevelIndex){
        if (currentSceneIndex != SceneManager.GetSceneByBuildIndex(nextLevelIndex)){
            SceneManager.LoadScene(nextLevelIndex);
        }
    }
}
