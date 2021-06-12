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
            generalScriptGManager.frozen = true;
            sceneRandomizer.NextScene();
        }
    }
}
