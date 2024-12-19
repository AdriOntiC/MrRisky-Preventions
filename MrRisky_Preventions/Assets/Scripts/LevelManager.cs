using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Level currentLevel;
    [SerializeField] GameObject currentTarget;

    public static LevelManager instance;

    void Awake(){
        instance = this;
    }

    void CheckWin(int option){
        if(currentLevel.Options[option].IsCorrect){
            currentLevel.Options[option].gameObject.SetActive(false);
            UIManager.instance.ChangeScreen(UIManager.instance.winScreen);
            foreach (Level lvl in UIManager.instance.signalsPlay.GetComponentsInChildren<Level>()){
                if (lvl.m_name == currentLevel.m_name){
                    lvl.GetComponent<Image>().color = Color.white;
                }
            }
            currentTarget.SetActive(false);
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
        currentTarget = currentLevel.transform.parent.gameObject;
        DisplayOptions();
    }

    void DisplayOptions(){
        for (int i = 0; i < currentLevel.Options.Count; i++){
            UIManager.instance.options[i].GetComponentInChildren<TextMeshProUGUI>().text = currentLevel.Options[i].m_name;
            UIManager.instance.options[i].GetComponentsInChildren<Image>()[1].sprite = currentLevel.Options[i].image;
        }
        UIManager.instance.ChangeScreen(UIManager.instance.optionsScreen);
    }

    public void PlayOption(int option){
        currentLevel.Options[option].gameObject.SetActive(true);
        StartCoroutine(OptionAnim(option));
    }

    IEnumerator OptionAnim(int option){
        yield return new WaitForSeconds(2f);
        CheckWin(option);
    }
}
