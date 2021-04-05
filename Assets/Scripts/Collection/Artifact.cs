using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField]
    private string _artifactName; //artifact name convention is *Minigame*+Artifact+*Number*

    public Material CollectedMaterial;

    private void Start()
    {
        if(PlayerPrefs.GetInt(_artifactName) ==1) // 1 means it has been unlocked, 0 if it hasn't (standard is 0)
        {
            IsCollected();
        }
        else
        {
            IsNotCollected();
        }
    }

    private void IsNotCollected()
    {
        Debug.Log("Not collected yet");
    }

    private void IsCollected()
    {
        this.GetComponent<Renderer>().material = CollectedMaterial;
    }
}
