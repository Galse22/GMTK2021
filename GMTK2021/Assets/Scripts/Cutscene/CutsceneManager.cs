using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Sprite[] imageArray;
    public Image baseImage;
    public int sceneNumber;
    int amountsButton;

    public void ChangeImage()
    {
        amountsButton++;
        if(amountsButton < imageArray.Length)
        {
            baseImage.overrideSprite = imageArray[amountsButton];
        }
        else
        {
            ActualLoadScene();
        }
    }

    void ActualLoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
