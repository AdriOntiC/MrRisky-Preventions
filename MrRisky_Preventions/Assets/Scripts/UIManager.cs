using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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

    public static UIManager instance;

    void Start(){
        instance = this;
        currentScreen = playScreen;
        topTime.text = PlayerPrefs.GetFloat("TopTime").ToString();
    }

    public void ChangeScreen(GameObject screen){
        currentScreen.SetActive(false);
        currentScreen = screen;
        currentScreen.SetActive(true);
    }

    public void ShowPopup(GameObject popup){
        popup.SetActive(true);
    }

    public void HidePopup(GameObject popup){
        popup.SetActive(false);
    }
}
