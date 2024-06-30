using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour, IPointerDownHandler
{
    public int targetScene;
    public GameObject transition;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TransitionScript transitionScript = transition.GetComponent<TransitionScript>();
        transitionScript.targetScene = targetScene;
        
        transitionScript.PlayAnim();
    }
}
