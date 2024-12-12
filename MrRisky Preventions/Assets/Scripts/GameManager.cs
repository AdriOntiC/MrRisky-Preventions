using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTime;
    public float topTime;
    public float trustLevel;
    int completedLevels;
    string savePath;
    bool isCounting;

    public static GameManager instance;

    void Start(){
        instance = this;
    }

    public void AddCompletedLvl(){
        completedLevels++;
    }

    void StartCounting(){

    }

    void StopCounting(){

    }

    void PlayGame(){

    }
}
