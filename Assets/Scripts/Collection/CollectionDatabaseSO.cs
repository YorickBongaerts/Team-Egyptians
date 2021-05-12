using System.Collections.Generic;
using UnityEngine;

namespace MexiColeccion.Collection
{
    [CreateAssetMenu(fileName = "EmptyCollectionDatabase", menuName = "ScriptableObjects/CollectionDatabase")]
    public class CollectionDatabaseSO : ScriptableObject
    {
        public List<ArtifactSO> Artifacts;

        public List<string> SceneNames;
    }
}
