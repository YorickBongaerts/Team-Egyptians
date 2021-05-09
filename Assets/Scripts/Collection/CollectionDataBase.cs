using System.Collections.Generic;
using UnityEditor;
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
        => Resources.Load<CollectionDatabaseSO>("Collection/DefaultCollectionDatabase");
        //=> AssetDatabase.LoadAssetAtPath("Assets/Editor/ScriptableObjects/Collection/DefaultCollectionDatabase.asset"
        //, typeof(CollectionDatabaseSO)) as CollectionDatabaseSO;

        public static List<ArtifactSO> Artifacts
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
        public static string GetSceneName(Minigame minigame)
        {
            return Database.SceneNames[(int)minigame];
        }

        public static List<ArtifactSO> GetMinigameArtifacts(Minigame minigame)
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

        public static List<ArtifactSO> GetMinigameArtifacts(string minigameScene)
        {
            Minigame minigame = (Minigame)Database.SceneNames.IndexOf(minigameScene);

            return GetMinigameArtifacts(minigame);
        }

        public static List<string> GetMinigameArtifactNames(Minigame minigame)
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

        public static List<string> GetMinigameArtifactNames(string minigameScene)
        {
            Minigame minigame = (Minigame)Database.SceneNames.IndexOf(minigameScene);

            return GetMinigameArtifactNames(minigame);
        }

        public static void ClearAllArtifactsData()
        {
            for (int i = 0; i < Database.Artifacts.Count; i++)
            {
                string s = Database.Artifacts[i].Name;
                PlayerPrefs.SetInt(s, 0);
                Debug.Log(s + " " + PlayerPrefs.GetInt(s));
            }
        }
        #endregion

        #region PlayerScoreMessageTracker
        //===================================================================================================================
        // tis should technicaly get its own script, but it feels weird to make a new script just to keep track for 2 strings.
        //this is used to keep track of player score between game scene and game over scene.
        //===================================================================================================================
        public static int PlayerScore;
        public static string LastGameSceneName;
        #endregion
    }
}