using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Movie
{
    [SerializeField] List<Option> options = new List<Option>();

    public List<Option> Options { get => options;}

    public static Level instance;

    void Start(){
        instance = this;
    }
}
