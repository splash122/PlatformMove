using UnityEngine;
using UnityEngine.UI;

public class LobbyWindowManager : MonoBehaviour
{
    public GameObject checkLvl1;
    public Button buttonLvl2;

    // Start is called before the first frame update
    void Start()
    {
        buttonLvl2 = GameObject.Find("Canvas/LevelButtons/Level2Button").GetComponent<Button>();
        buttonLvl2.interactable = false;
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
