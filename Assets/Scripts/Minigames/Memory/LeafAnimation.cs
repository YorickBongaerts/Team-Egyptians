using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeafAnimation : MonoBehaviour, IPointerDownHandler
{
    //private Animator animator;
    private List<GameObject> children = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            children.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }
    public void OnCardTapped(Animator animator)
    {
        animator.Play("Swipe Off");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
        foreach (var leaf in children)
        {
            OnCardTapped(leaf.transform.GetComponent<Animator>());
        }
    }
}
