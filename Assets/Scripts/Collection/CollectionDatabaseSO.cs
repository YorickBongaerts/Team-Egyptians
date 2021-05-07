using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
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
