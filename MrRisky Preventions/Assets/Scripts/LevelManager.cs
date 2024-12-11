using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Level currentLevel;

    void CheckWin(int option){
        if(Level.instance.Options[0].IsCorrect){
            // Open win screen (UI Manager)
            // Add completed lvl (GameManager)
        }
        else{
            // Open lose screen
        }
    }

    public void SetLevel(Level lvl){
        currentLevel = lvl;
    }

    void DisplayOptions(){
        // Set options texts and images (UI Manager)
    }

    void DisplayLevel(){
        currentLevel.gameObject.SetActive(true);
        // currentLevel.instance
    }
}
