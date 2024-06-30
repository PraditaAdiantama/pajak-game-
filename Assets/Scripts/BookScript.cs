using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BookScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform thisRectTransform, targetRectTransform;
    public GameObject enabledObject, disabledObject;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Vector2 thisOriginalPostion;

    private void Awake()
    {
        thisRectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();

        PlayerPrefs.SetInt("bookDone", 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        thisOriginalPostion = thisRectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        thisRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!IsPlaced())
        {
            thisRectTransform.anchoredPosition = thisOriginalPostion;
        }
        else
        {
            StartCoroutine(Done());
        }
    }

    private bool IsPlaced()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(thisRectTransform.position);

        foreach (var collider in colliders)
        {
            if (thisRectTransform.CompareTag("Untagged")) return false;
            if (collider.CompareTag(thisRectTransform.tag + "Target"))
            {
                int orderDone = PlayerPrefs.GetInt("bookDone");

                collider.GetComponent<CanvasGroup>().alpha = 1f;

                if (orderDone >= 2)
                {
                    StartCoroutine(End());
                }

                PlayerPrefs.SetInt("bookDone", orderDone += 1);


                return true;
            }
        }


        return false;
    }

    IEnumerator Done()
    {
        gameObject.SetActive(false);

        yield return new WaitForSeconds(1);
    }

    IEnumerator End()
    {
        enabledObject.SetActive(true);

        yield return new WaitForSeconds(1);

        disabledObject.SetActive(false);
    }
}
