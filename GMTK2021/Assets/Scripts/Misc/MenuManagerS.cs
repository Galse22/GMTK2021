using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerS : MonoBehaviour
{
    public SceneRandomizer sceneRandomizer;
    public void TransitionToScene(int i)
    {
       SceneManager.LoadScene(i);
    }
    public void SceneRandomizerFunc()
    {
        sceneRandomizer.NextScene();
    }
}
