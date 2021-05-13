using MexiColeccion.Minigames.Memory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeafAnimation : MonoBehaviour, IPointerDownHandler
{
    //private Animator animator;
    private List<GameObject> children = new List<GameObject>();
    public SceneManager sceneController;

    private void Start()
    {
        sceneController = GameObject.FindObjectOfType<SceneManager>();
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
        Debug.Log(eventData.pressPosition);
        //make sure this is a general scene controller
        sceneController.AfterClick(this.gameObject.transform.parent.gameObject);
        //foreach (var leaf in children)
        //{
        //    OnCardTapped(leaf.transform.GetComponent<Animator>());
        //}
    }
}
