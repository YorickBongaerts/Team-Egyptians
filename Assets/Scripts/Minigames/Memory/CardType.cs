using UnityEngine;

namespace MexiColeccion.Minigames.Memory
{
    [CreateAssetMenu(fileName = "MemoryCardType", menuName = "ScriptableObjects/memoryCards")]
    public class CardType : ScriptableObject
    {
        //public int _id;
        public string Cardname;
        public Sprite ImageFront;
        public Sprite ImageBack;
    }
}