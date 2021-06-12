using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePosition : MonoBehaviour
{
    public GameObject[] gosToRandomize;
    public List<GameObject> placeToPutTheThingies;
    int i;
    private void Awake() {
        foreach(GameObject goToRandomize in gosToRandomize)
        {
            i = Random.Range (0, placeToPutTheThingies.Count);
            goToRandomize.GetComponent<RectTransform>().anchoredPosition = placeToPutTheThingies[i].GetComponent<RectTransform>().anchoredPosition;
            placeToPutTheThingies.RemoveAt(i);
        }
    }
}
