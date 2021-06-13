using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LManagerFuncs : MonoBehaviour
{
    GeneralScriptGManager generalScriptGManager;
    SceneRandomizer sceneRandomizer;
    GameObject GGameManager;
    public int objsNecessary;
    int objsPut;
    public Text timerText;

    public GameObject putSFX;
    public GameObject nextLvlSFX;
    void Awake()
    {
        GGameManager = GameObject.FindWithTag("GGameManager");
        generalScriptGManager = GGameManager.GetComponent<GeneralScriptGManager>();
        sceneRandomizer = GGameManager.GetComponent<SceneRandomizer>();
        generalScriptGManager.timerText = timerText;
        generalScriptGManager.frozen = false;
    }
    public void IncreaseScoreGScript()
    {
        objsPut++;
        generalScriptGManager.IncreaseScore();
        if(objsPut >= objsNecessary)
        {
            Instantiate(nextLvlSFX, Vector3.zero, Quaternion.identity);
            generalScriptGManager.frozen = true;
            sceneRandomizer.NextScene();
        }
        else
        {
            GameObject goInstantiated = Instantiate(putSFX, Vector3.zero, Quaternion.identity);
            goInstantiated.GetComponent<AudioSource>().pitch = Random.Range(0.2f,1.2f);
        }
    }
}
