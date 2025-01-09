using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneManager : MonoBehaviour
{
    public static SimpleSceneManager instance;

    void Awake()
    {
        instance = this;
    }

    public void LoadScene(string sceneInfo){
        if(sceneInfo.Split(",")[1] == "true"){
            PlayerPrefs.SetInt("firstTime", 0);
        }
        SceneManager.LoadScene(sceneInfo.Split(",")[0]);
    }
}
