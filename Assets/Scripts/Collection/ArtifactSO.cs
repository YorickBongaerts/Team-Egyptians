using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MexiColeccion.Collection
{
    //[CreateAssetMenu(fileName = "Unnamed Artifact", menuName = "ScriptableObjects/Artifact")]
    [Serializable]
    public class ArtifactSO
    {
        [SerializeField] private string _name = "New Artifact";

        [SerializeField] private Minigame _minigame;

        [SerializeField] private Mesh _mesh; // might need to change to gameobject

        [TextArea]
        [SerializeField] private string _info = "Description, link to Museum Website, etc.";

        internal string Name => _name;
        internal Minigame Minigame => _minigame;
        internal Mesh Mesh => _mesh;
        internal string Info => _info;
    }
}
