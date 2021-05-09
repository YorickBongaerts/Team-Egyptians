using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MexiColeccion.Collection
{
    //[CreateAssetMenu(fileName = "Unnamed Artifact", menuName = "ScriptableObjects/Artifact")]
    [Serializable]
    public class ArtifactSO
    {
        [Tooltip("The display name that is used in the game.")]
        [SerializeField] private string _name = "New Artifact";

        [Tooltip("The minigame the user has to play to collect this artifact.")]
        [SerializeField] private Minigame _minigame;

        [Tooltip("The actual 3D model for use in the viewer.")]
        [SerializeField] private Mesh _mesh; // might need to change to gameobject

        [Tooltip("The image that is shown when you collect the artifact.")]
        [SerializeField] private Sprite _referenceImage;

        [TextArea]
        [Tooltip("A small info box to inform the user about the artifact. This can also be just a link to an informative web page.")]
        [SerializeField] private string _info = "Description, link to Museum Website, etc.";

        internal string Name => _name;
        internal Minigame Minigame => _minigame;
        internal Mesh Mesh => _mesh;
        internal string Info => _info;
        internal Sprite Image => _referenceImage;
    }
}
