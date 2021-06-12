using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // called when player begins dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    // called when dragging
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // called when dragging is stopped
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        canvasGroup.blocksRaycasts = true;
    }

    // called when mouse is pressed whilst on top of object
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
    }
}
