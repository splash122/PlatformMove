using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyWindowManager : MonoBehaviour
{
    public GameObject checkLvl1;
    // Start is called before the first frame update
    void Start()
    {
        checkLvl1 = GameObject.FindWithTag("Check1Lvl");
        checkLvl1.SetActive(false);
        int levelPassed = PlayerPrefs.GetInt("LevelPassedNumber",0);
        print("Number of level passed");
        print(levelPassed);
        if(levelPassed == 1){
            checkLvl1.SetActive(true);
    }
    }
}
