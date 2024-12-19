using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float currentTime;
    float topTime = 999999;
    public float trustLevel;
    int completedLevels;
    bool isCounting;

    public List<GameObject> targets;

    public GameObject currentTrustLevel;

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

        currentTrustLevel = UIManager.instance.trustLevelRed;
        SetTrustLevel();
    }

    public void AddCompletedLvl(){
        completedLevels++;
        if (completedLevels == 5){
            UIManager.instance.ChangeScreen(UIManager.instance.winGameScreen);
        }
    }

    void StartCounting(){
        currentTime = 0;
        StartCoroutine(CountSeconds());
    }

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
            SetTrustLevel();
        }
        
        UIManager.instance.hiddenButtons.SetActive(false);
        UIManager.instance.startGameBtn.SetActive(true);
        UIManager.instance.ChangeScreen(UIManager.instance.playScreen);
    }

    public void PlayGame(){
        isCounting = true;
        completedLevels = 0;
        StartCounting();
        UIManager.instance.hiddenButtons.SetActive(true);
        UIManager.instance.startGameBtn.SetActive(false);
        foreach (Level lvl in UIManager.instance.signalsPlay.GetComponentsInChildren<Level>()){
            Color colorG;
            if (ColorUtility.TryParseHtmlString("#3F3F3F", out colorG)){
                lvl.GetComponent<Image>().color = colorG;
            }
        }

        foreach (GameObject trg in targets){
            trg.SetActive(true);
        }
        UIManager.instance.ChangeScreen(UIManager.instance.cameraScreen);
    }

    public void SetTrustLevel(){
        currentTrustLevel.SetActive(false);
        if(topTime >= 360 && topTime < 720){
            currentTrustLevel = UIManager.instance.trustLevelYellow;
        }
        if(topTime >= 720 || topTime == 0){
            currentTrustLevel = UIManager.instance.trustLevelRed;
        }
        if(topTime < 360){
            currentTrustLevel = UIManager.instance.trustLevelGreen;
        }
        currentTrustLevel.SetActive(true);
    }
}
