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

    public GameObject[] musicList;
    public int lastMusic = -1;
    public int currentMusic;

    public GameObject buttonSFX;
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
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        if(sceneName == "Menu")
        {
            Destroy(GameObject.FindWithTag("MenuMusic"));
            GameObject goInstantiated = Instantiate(buttonSFX, Vector3.zero, Quaternion.identity);
            goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.2f, 1.4f);
            currentMusic = Random.Range(0, musicList.Length);
            if(currentMusic != lastMusic)
            {
                GameObject music = Instantiate(musicList[currentMusic], Vector3.zero, Quaternion.identity);
                DontDestroyOnLoad(music);
                lastMusic = currentMusic;
            }
            else
            {
                if(currentMusic == 0)
                {
                    GameObject music = Instantiate(musicList[1], Vector3.zero, Quaternion.identity);
                    DontDestroyOnLoad(music);
                    lastMusic = 0;
                }
                else
                {
                    GameObject music = Instantiate(musicList[0], Vector3.zero, Quaternion.identity);
                    DontDestroyOnLoad(music);
                    lastMusic = currentMusic;
                }
            }
        }
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
