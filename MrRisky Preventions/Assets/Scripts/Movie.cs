using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class Movie : MonoBehaviour
{
    public string name;
    public string description;

    public Sprite image;

    public void StartAnims(){
        foreach (Animator animator in GetComponentsInChildren<Animator>()){
            animator.enabled = true;
        }
    }

    public void StopAnims(){
        foreach (Animator animator in GetComponentsInChildren<Animator>()){
            animator.enabled = true;
        }
    }
}
