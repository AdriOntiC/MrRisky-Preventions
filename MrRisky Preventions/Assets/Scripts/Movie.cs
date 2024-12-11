using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movie : MonoBehaviour
{
    public string name;
    public string description;

    public string GetPicture(){
        return name + ".png";
    }

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
