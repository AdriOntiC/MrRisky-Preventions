using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTime;
    float topTime;
    public float trustLevel;
    int completedLevels;
    string savePath;
    bool isCounting;

    public static GameManager instance;

    void Start(){
        instance = this;
        completedLevels = 0;
        topTime = 999999999;
    }

    public void AddCompletedLvl(){
        completedLevels++;
    }

    void StartCounting(){
        currentTime = 0; // Reinicia el contador
        StartCoroutine(CountSeconds());
    }

    // Coroutine que cuenta los segundos
    private IEnumerator CountSeconds()
    {
        while (isCounting)
        {
            yield return new WaitForSeconds(1f);
            currentTime++;
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        UIManager.instance.currentTime.text = currentTime.ToString();
    }

    public void StopGame(){
        isCounting = false;
        
        if(currentTime < topTime && completedLevels == 5){
            topTime = currentTime;
            UIManager.instance.topTime.text = topTime.ToString();
            PlayerPrefs.SetFloat("TopTime", topTime);
            // save toptime persistent
        }
    }

    public void PlayGame(){
        isCounting = true;
        StartCounting();
        UIManager.instance.ChangeScreen(UIManager.instance.cameraScreen);
    }
}
