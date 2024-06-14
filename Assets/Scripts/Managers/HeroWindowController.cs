using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWindowController : MonoBehaviour
{
    public GameObject textNotEnough;
    public CoinsSkinManager coinsSkinManager;

    public GameObject oldGirlButton;
    public GameObject oldBoyButton;
    public GameObject oldPolicemanButton;
    public GameObject newGirlButton;
    public GameObject newBoyButton;
    public GameObject newPolicemanButton;
    public GameObject girlBack;
    public GameObject boyBack;
    public GameObject policemanBack;
    // Start is called before the first frame update
    void Start() {
        textNotEnough = GameObject.FindWithTag("TextNotEnough");
        textNotEnough.SetActive(false);
        girlBack = GameObject.Find("/Canvas/Default/ImageChosen");
        boyBack = GameObject.Find("/Canvas/Man/ImageChosen2");
        policemanBack = GameObject.Find("/Canvas/PoliceMan/ImageChosen3");
        girlBack.SetActive(false);
        boyBack.SetActive(false);
        policemanBack.SetActive(false);
        oldGirlButton = GameObject.Find("/Canvas/Default/Image/ButtonDefault");
        oldBoyButton = GameObject.Find("/Canvas/Man/Image/ButtonMan");
        oldPolicemanButton = GameObject.Find("/Canvas/PoliceMan/Image/ButtonPoliceman");
        newGirlButton = GameObject.Find("/Canvas/Default/Image/ButtonNext");
        newBoyButton = GameObject.Find("/Canvas/Man/Image/ButtonNext2");
        newPolicemanButton = GameObject.Find("/Canvas/PoliceMan/Image/ButtonNext3");
        oldGirlButton.SetActive(false);
        newGirlButton.SetActive(true);
        newBoyButton.SetActive(false);
        newPolicemanButton.SetActive(false);

        if (PlayerPrefs.GetInt("BoyBought") == 1) {
            print("Boy bought earlier");
            coinsSkinManager.CheckNewButtonActive("Boy");
        }
        if (PlayerPrefs.GetInt("PolicemanBought") == 1) {
            print("Policeman bought earlier");
            coinsSkinManager.CheckNewButtonActive("Policeman");
        }
        if (PlayerPrefs.GetString("HeroChosen") == "Player") {
            coinsSkinManager.ChooseHeroDefault();
        }
        if (PlayerPrefs.GetString("HeroChosen") == "Boy") {
            coinsSkinManager.ChooseHeroMan();
        }
        if (PlayerPrefs.GetString("HeroChosen") == "Policeman") {
            coinsSkinManager.ChooseHeroPoliceman();
        }
    }
}
