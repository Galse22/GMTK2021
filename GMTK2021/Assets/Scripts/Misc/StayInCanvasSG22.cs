using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInCanvasSG22 : MonoBehaviour
{
    RectTransform rectTransform;
    public float maxX;
    public float maxY;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine("BounderiesCor");
    }

    IEnumerator BounderiesCor()
    {
        yield return new WaitForSeconds(0.3f);
            if(rectTransform.transform.localPosition.x > maxX)
            {
                rectTransform.transform.localPosition = new Vector2(maxX - 10, rectTransform.transform.localPosition.y);
            }
            else if(rectTransform.localPosition.x < -maxX)
            {
                rectTransform.transform.localPosition = new Vector2(-maxX + 10, rectTransform.transform.localPosition.y);
            }

            if(rectTransform.localPosition.y > maxY)
            {
                rectTransform.transform.localPosition = new Vector2(rectTransform.transform.localPosition.x, maxY - 10);
            }
            else if(rectTransform.localPosition.y < -maxY)
            {
                rectTransform.transform.localPosition = new Vector2(rectTransform.transform.localPosition.x, -maxY + 10);
            }
        StartCoroutine("BounderiesCor");
    }
}
