using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToyScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform thisRectTransform, targetRectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Vector2 thisOriginalPostion;
    public CanvasGroup orderButton;

    private void Awake()
    {
        thisRectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();

        PlayerPrefs.SetInt("orderDone", 0);
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
            gameObject.SetActive(false);
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
                collider.GetComponent<Image>().color = Color.white;

                int orderDone = PlayerPrefs.GetInt("orderDone");

                targetRectTransform = collider.GetComponent<RectTransform>();

                PlayerPrefs.SetInt("orderDone", orderDone += 1);

                if (orderDone >= 1)
                {
                    orderButton.alpha = 1;
                }

                return true;
            }
        }

        return false;
    }

}
