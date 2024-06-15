using UnityEngine;
using UnityEngine.UI;

public class LobbyWindowManager : MonoBehaviour
{
    public GameObject checkLvl1;
    public GameObject checkLvl2;
    public Button buttonLvl2;

    // Start is called before the first frame update
    void Start()
    {
        buttonLvl2 = GameObject.Find("Canvas/LevelButtons/Level2Button").GetComponent<Button>();
        buttonLvl2.interactable = false;
        checkLvl1 = GameObject.FindWithTag("Check1Lvl");
        checkLvl1.SetActive(false);
        checkLvl2 = GameObject.FindWithTag("Check2Lvl");
        checkLvl2.SetActive(false);
        int levelPassed = PlayerPrefs.GetInt("LevelPassedNumber",0);
        print("Number of level passed");
        print(levelPassed);
        if(levelPassed == 1){
            checkLvl1.SetActive(true);
            buttonLvl2.interactable = true;
        }
        if(levelPassed == 2){
            checkLvl2.SetActive(true);
        }
    }
}
