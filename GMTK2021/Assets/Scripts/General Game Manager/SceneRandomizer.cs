using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomizer : MonoBehaviour
{
    public int[] scenes;
    int currentSceneIndex = 0;
    int currentSceneIndexM1;
    private int tempInt;
    private void Awake() {
        Shuffle();
    }

    // private void Update() {
    //     if(Input.GetButtonDown("Fire2"))
    //     {
    //         NextScene();
    //     }
    // }

    public void NextScene()
    {
        currentSceneIndex++;
        currentSceneIndexM1 = currentSceneIndex -1;
        if(currentSceneIndexM1 >= 0 && currentSceneIndexM1 < scenes.Length)
        {
            SceneManager.LoadScene(scenes[currentSceneIndexM1]);
        }
        else
        {
            currentSceneIndex = 1;
            SceneManager.LoadScene(scenes[0]);
        }
    }

    // https://answers.unity.com/questions/1189736/im-trying-to-shuffle-an-arrays-order.html
    void Shuffle() 
    {
        for (int i = 0; i < scenes.Length - 1; i++) 
        {
            int rnd = Random.Range(i, scenes.Length);
            tempInt = scenes[rnd];
            scenes[rnd] = scenes[i];
            scenes[i] = tempInt;
        }
    }
}
