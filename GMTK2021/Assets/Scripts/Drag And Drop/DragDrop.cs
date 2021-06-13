using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public GameObject pickUpSfx;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // called when player begins dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        GameObject goInstantiated = Instantiate(pickUpSfx, Vector3.zero, Quaternion.identity);
        goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.2f,1.2f);
    }

    // called when dragging
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // called when dragging is stopped
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    // called when mouse is pressed whilst on top of object
    public void OnPointerDown(PointerEventData eventData)
    {
    }
}
