using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("firstTime")){
           PlayerPrefs.SetInt("firstTime", 0); 
        }

        if(PlayerPrefs.GetInt("firstTime") != 0){
            SimpleSceneManager.instance.LoadScene("MainVuforia,false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!vp.isPlaying){
            PlayerPrefs.SetInt("firstTime", 1);
            SimpleSceneManager.instance.LoadScene("MainVuforia,false");
        }
    }
}
