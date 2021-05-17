using System.Collections.Generic;
using UnityEngine;

namespace MexiColeccion.Collection
{
    public enum Minigame
    {
        //==============================================
        // Add a new state to the enum for new minigames
        //==============================================
        Painter,
        Memory
    }

    public static class CollectionDatabase
    {
        private static CollectionDatabaseSO Database
        => Resources.Load<CollectionDatabaseSO>("DefaultCollectionDatabase");

        private static List<ArtifactSO> Artifacts
        {
            get
            {
                return Database.Artifacts;
            }
        }


        #region Methods
        //============================================================================
        // Use a similar structure as the existing methods if you want to add new ones
        //============================================================================
        internal static string GetSceneName(Minigame minigame)
        {
            return Database.SceneNames[(int)minigame];
        }

        internal static Minigame GetMinigameFromScene(string sceneName)
        {
            return (Minigame)Database.SceneNames.IndexOf(sceneName);
        }

        internal static List<ArtifactSO> GetMinigameArtifacts(Minigame minigame)
        {
            List<ArtifactSO> artifacts = new List<ArtifactSO>();

            for (int i = 0; i < Database.Artifacts.Count; i++)
            {
                ArtifactSO artifact = Database.Artifacts[i];
                if (artifact.Minigame == minigame)
                {
                    artifacts.Add(artifact);
                }
            }

            return artifacts;
        }

        internal static List<ArtifactSO> GetMinigameArtifacts(string minigameScene)
        {
            Minigame minigame = (Minigame)Database.SceneNames.IndexOf(minigameScene);

            return GetMinigameArtifacts(minigame);
        }

        internal static List<string> GetMinigameArtifactNames(Minigame minigame)
        {
            List<string> artifactNames = new List<string>();

            for (int i = 0; i < Database.Artifacts.Count; i++)
            {
                ArtifactSO artifact = Database.Artifacts[i];
                if (artifact.Minigame == minigame)
                {
                    artifactNames.Add(artifact.Name);
                }
            }

            return artifactNames;
        }

        internal static List<string> GetMinigameArtifactNames(string minigameScene)
        {
            Minigame minigame = (Minigame)Database.SceneNames.IndexOf(minigameScene);

            return GetMinigameArtifactNames(minigame);
        }

        internal static int GetArtifactIndex(ArtifactSO artifact)
        {
            return GetMinigameArtifacts(artifact.Minigame).IndexOf(artifact);
        }

        internal static ArtifactSO GetArtifactByName(string name, Minigame minigame)
        {
            int index = GetMinigameArtifactNames(minigame).IndexOf(name);
            return Artifacts[index];
        }

        internal static void ClearAllArtifactsData()
        {
            for (int i = 0; i < Database.Artifacts.Count; i++)
            {
                string s = Database.Artifacts[i].Name;
                PlayerPrefs.SetInt(s, 0);
                Debug.Log(s + " " + PlayerPrefs.GetInt(s));
            }
        }
        #endregion

        #region Game Loop Management
        internal static ArtifactSO LastWonArtifact;
        internal static int PlayerScore;
        internal static string LastGameSceneName;
        internal static bool ViewedArtifacts;
        internal static bool HasWon;
        #endregion
    }
}