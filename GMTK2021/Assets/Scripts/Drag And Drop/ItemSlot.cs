using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string desiredName;
    private Image thisImage;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        if( eventData.pointerDrag.name == desiredName )
        {
            thisImage = GetComponent<Image>();
            thisImage.sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            thisImage.SetNativeSize();
            eventData.pointerDrag.SetActive(false);
            //thisRect = GetComponent<RectTransform>();
            //otherRect = eventData.pointerDrag.GetComponent<RectTransform>();
            //otherRect.anchoredPosition.x = thisRect.anchoredPosition.x + offset.x;
            //otherRect.anchoredPosition.y = thisRect.anchoredPosition.y + offset.y;
        }
    }
}
