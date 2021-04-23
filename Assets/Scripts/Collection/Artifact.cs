using System;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public enum MinigameType
    {
        memory,
        painter
    }

    public MinigameType TypeOfMinigame;
    public int artifactIndex;
    private string _artifactName; 


    public Material CollectedMaterial; // code here has to chage depending on implemetation relics

    private void Start()
    {
        _artifactName = GetCorrectArtifactNameFromDataBase();

        Debug.Log(_artifactName);

        if (PlayerPrefs.GetInt(_artifactName) == 1) // 1 means it has been unlocked, 0 if it hasn't (standard is 0)
            IsCollected();        
        else
            IsNotCollected();
    }

    private string GetCorrectArtifactNameFromDataBase()
    {
        string artifactName = "default";

        if(TypeOfMinigame == MinigameType.memory)
            artifactName = CollectionDataBase.MemoryArtifacts[artifactIndex];

        else if(TypeOfMinigame == MinigameType.painter)
            artifactName = CollectionDataBase.PainterArtifacts[artifactIndex];

        return artifactName;
    }

    private void IsNotCollected() // code here has to chage depending on implemetation relics
    {
        Debug.Log("Not collected yet");
    }

    private void IsCollected() // code here has to chage depending on implemetation relics
    {
        this.GetComponent<Renderer>().material = CollectedMaterial;
    }
}
