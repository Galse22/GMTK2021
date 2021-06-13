using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string desiredName;
    private Image thisImage;
    public LManagerFuncs lManagerFuncs;
    public void OnDrop(PointerEventData eventData)
    {
        if( eventData.pointerDrag.name == desiredName )
        {
            thisImage = GetComponent<Image>();
            thisImage.sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            thisImage.SetNativeSize();
            CinemachineShake.Instance.ShakeCamera (3, 0.15f);
            eventData.pointerDrag.SetActive(false);
            lManagerFuncs.IncreaseScoreGScript();
        }
    }
}
