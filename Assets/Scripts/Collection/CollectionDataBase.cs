using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Minigame
{
    //==============================================
    // Add a new state to the enum for new minigames
    //==============================================
    Painter,
    Memory
}

public static class CollectionDataBase
{
    private static List<string> _artifacts;

    // ===============================================
    // Add the artifacts for all minigames to the list
    //================================================
    public static List<string> Artifacts
    {
        get
        {
            if (_artifacts.Count <= 0 || _artifacts == null)
            {
                _artifacts = new List<string>();

                _artifacts.AddRange(_memoryArtifacts);  // <-- memory
                _artifacts.AddRange(_painterArtifacts); // <-- painter
                                                        // <-- ...
            }
            return _artifacts;
        }
    }

    #region Minigame Scene Names
    //================================================
    // Add the scene names for the different minigames
    //================================================
    private static readonly string _painterMinigame = "Minigame-Teotihuacan";
    private static readonly string _memoryMiniGame = "MiniGame-Memory";
    #endregion

    #region Artifact Names Per Minigame
    //============================================
    // Add the names of the artifacts per minigame
    //============================================
    private static string[] _painterArtifacts = new string[] 
    {
        "PainterArtifact1",
        "PainterArtifact2",
        "PainterArtifact3",
        "PainterArtifact4"
    };

    private static string[] _memoryArtifacts = new string[]
    {
        "MemoryArtifact1",
        "MemoryArtifact2",
        "MemoryArtifact3",
        "MemoryArtifact4"
    };
    #endregion

    #region Methods
    //============================================================================
    // Use a similar structure as the existing methods if you want to add new ones
    //============================================================================
    public static string GetSceneName(Minigame minigame)
    {
        switch (minigame)
        {
            case Minigame.Memory:
                return _memoryMiniGame;
            case Minigame.Painter:
                return _painterMinigame;
            default:
                throw new KeyNotFoundException();
        }
    }

    public static string[] GetMinigameArtifacts(Minigame minigame)
    {
        switch (minigame)
        {
            case Minigame.Memory:
                return _memoryArtifacts;
            case Minigame.Painter:
                return _painterArtifacts;
            default:
                throw new KeyNotFoundException();
        }
    }

    public static string[] GetMinigameArtifacts(string minigameScene)
    {
        if (minigameScene.Equals(_painterMinigame))
        {
            return _painterArtifacts;
        }
        if (minigameScene.Equals(_memoryMiniGame))
        {
            return _memoryArtifacts;
        }
        throw new KeyNotFoundException();
    }

    public static void ClearAllArtifactsData()
    {
        foreach (string s in Artifacts)
        {
            PlayerPrefs.SetInt(s, 0);
            Debug.Log(s + " " + PlayerPrefs.GetInt(s));
        }
    }
    #endregion
}