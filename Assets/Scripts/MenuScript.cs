using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour, IPointerDownHandler
{
    public int targetScene;
    public GameObject transition;
    private AudioSource clickSound;
    private RectTransform rectTransform;

    private void Awake()
    {
        clickSound = GetComponent<AudioSource>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickSound.Play();
        rectTransform.localScale = new Vector3(1.1f, 1.1f, 0);

        TransitionScript transitionScript = transition.GetComponent<TransitionScript>();
        transitionScript.targetScene = targetScene;
        
        transitionScript.PlayAnim();
    }
}
