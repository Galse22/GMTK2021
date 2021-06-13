using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerS : MonoBehaviour
{
    public SceneRandomizer sceneRandomizer;
    public GameObject buttonSFX;
    public GameObject nHSsfx;
    public bool hssfx;

    private void Start() {
        if(hssfx)
        {
            Instantiate(nHSsfx, Vector3.zero, Quaternion.identity);
        }
    }
    public void TransitionToScene(int i)
    {
        GameObject goInstantiated = Instantiate(buttonSFX, Vector3.zero, Quaternion.identity);
        goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        SceneManager.LoadScene(i);
    }
    public void SceneRandomizerFunc()
    {
        sceneRandomizer.NextScene();
    }
}
