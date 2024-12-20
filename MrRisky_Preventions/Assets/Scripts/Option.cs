using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : Movie
{
    [SerializeField] bool isCorrect;

    public bool IsCorrect { get => isCorrect; set => isCorrect = value; }

    public static Option instance;

    void Awake(){
        instance = this;
    }
}
