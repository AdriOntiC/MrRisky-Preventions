using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentTime;
    float topTime = 999999999;
    public float trustLevel;
    int completedLevels;
    string savePath;
    bool isCounting;

    public static GameManager instance;

    void Awake(){
        instance = this;
    }

    void Start(){
        completedLevels = 0;

        if (PlayerPrefs.HasKey("TopTime")){
            topTime = PlayerPrefs.GetFloat("TopTime");
            UIManager.instance.SetTopTime();
        }
        else PlayerPrefs.SetFloat("TopTime", topTime);
    }

    public void AddCompletedLvl(){
        completedLevels++;
        if (completedLevels == 5){
            UIManager.instance.ChangeScreen(UIManager.instance.winGameScreen);
        }
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
            PlayerPrefs.SetFloat("TopTime", topTime);
            UIManager.instance.SetTopTime();
        }
        
        UIManager.instance.hiddenButtons.SetActive(false);
        UIManager.instance.startGameBtn.SetActive(true);
        UIManager.instance.ChangeScreen(UIManager.instance.playScreen);
    }

    public void PlayGame(){
        isCounting = true;
        StartCounting();
        UIManager.instance.hiddenButtons.SetActive(true);
        UIManager.instance.startGameBtn.SetActive(false);
        UIManager.instance.ChangeScreen(UIManager.instance.cameraScreen);
    }
}
