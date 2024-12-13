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
