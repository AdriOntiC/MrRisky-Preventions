using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Level currentLevel;

    public static LevelManager instance;

    void Start(){
        instance = this;
    }

    void CheckWin(int option){
        if(Level.instance.Options[option].IsCorrect){
            currentLevel.Options[option].gameObject.SetActive(false);
            UIManager.instance.ChangeScreen(UIManager.instance.winScreen);
            GameManager.instance.AddCompletedLvl();
        }
        else{
            currentLevel.Options[option].gameObject.SetActive(false);
            UIManager.instance.ChangeScreen(UIManager.instance.loseScreen);
        }
    }

    public void SetLevel(Level lvl){
        currentLevel = lvl;
        currentLevel.gameObject.SetActive(true);
        DisplayOptions();
    }

    void DisplayOptions(){
        for (int i = 0; i < currentLevel.Options.Count; i++){
            UIManager.instance.options[i].GetComponentInChildren<TextMeshProUGUI>().text = currentLevel.Options[i].name;
            UIManager.instance.options[i].GetComponentInChildren<Image>().sprite = currentLevel.Options[i].image;
        }
        UIManager.instance.ChangeScreen(UIManager.instance.optionsScreen);
    }

    public void PlayOption(int option){
        currentLevel.gameObject.SetActive(false);
        currentLevel.Options[option].gameObject.SetActive(true);
        CheckWin(option);
    }

    // void DisplayLevel(){
    //     currentLevel.gameObject.SetActive(true);
    //     // currentLevel.instance
    // }
}
