using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject scrollingBg;
    public GameObject winGameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject trustScreen;
    public GameObject playScreen;
    public GameObject cameraScreen;
    public GameObject signalsScreen;
    public GameObject settingsScreen;
    public GameObject optionsScreen;
    public List<GameObject> options;
    public TextMeshProUGUI currentTime;
    public TextMeshProUGUI topTime;
    private GameObject currentScreen;

    public GameObject hiddenButtons;
    public GameObject startGameBtn;
    public GameObject signalsPlay;
    public GameObject trustLevelRed;
    public GameObject trustLevelYellow;
    public GameObject trustLevelGreen;

    public GameObject ARCamera;

    public static UIManager instance;

    void Awake(){
        instance = this;
    }

    void Start(){
        currentScreen = playScreen;
    }

    public void ChangeScreen(GameObject screen){
        currentScreen.SetActive(false);
        currentScreen = screen;
        if(currentScreen == cameraScreen || currentScreen == optionsScreen){
            scrollingBg.SetActive(false);
            ARCamera.SetActive(true);
        }
        else{
            scrollingBg.SetActive(true);
            ARCamera.SetActive(false);
        }
        currentScreen.SetActive(true);
    }

    public void ShowPopup(GameObject popup){
        popup.SetActive(true);
    }

    public void HidePopup(GameObject popup){
        popup.SetActive(false);
    }

    public void SetTopTime(){
        topTime.text = PlayerPrefs.GetFloat("TopTime").ToString();
    }
}
