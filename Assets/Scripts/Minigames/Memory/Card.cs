using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public int id;
    public string Cardname;
    public Sprite ImageFront;
    public Sprite ImageBack;


}
