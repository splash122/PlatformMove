using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsSkinManager : MonoBehaviour
{
    private GameObject coinsSkin;
    public GameObject textNotEnough;
    public Text skinsText;
    public static int skinsCount;
    //public int skinsCount = 0;
    private float resultProgress;
    public GameManager gameManager;
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

    void Start()
    {
        skinsCount = PlayerPrefs.GetInt("CurrentSkinCoins", 0);
        coinsSkin = GameObject.FindWithTag("Coin");
        resultProgress = Mathf.Round(skinsCount);
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
        girlBack = GameObject.Find("/Canvas/Default/ImageChosen");
        boyBack = GameObject.Find("/Canvas/Man/ImageChosen2");
        policemanBack = GameObject.Find("/Canvas/PoliceMan/ImageChosen3");
        oldGirlButton = GameObject.Find("/Canvas/Default/Image/ButtonDefault");
        oldBoyButton = GameObject.Find("/Canvas/Man/Image/ButtonMan");
        oldPolicemanButton = GameObject.Find("/Canvas/PoliceMan/Image/ButtonPoliceman");
        newGirlButton = GameObject.Find("/Canvas/Default/Image/ButtonNext");
        newBoyButton = GameObject.Find("/Canvas/Man/Image/ButtonNext2");
        newPolicemanButton = GameObject.Find("/Canvas/PoliceMan/Image/ButtonNext3");

    }

    public void IncrementSkinsCoins()
    {

        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
        PlayerPrefs.SetInt("CurrentSkinCoins", skinsCount);
    }

    public void DecrementIfSkinBought(int coinsForSkin, string heroName)
    {
        if(skinsCount>=coinsForSkin){
            print("HeroBought");
            print(heroName);
            skinsCount -= coinsForSkin;
            resultProgress = Mathf.Round(skinsCount);
            skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
            CheckNewButtonActive(heroName);
            PlayerPrefs.SetInt("CurrentSkinCoins", skinsCount);
        }
        else{
            print("No money");
            textNotEnough.SetActive(true);
        }

    }

    public void CheckNewButtonActive(string heroName){
        if(heroName == "Boy") {
            gameManager.secondSkinPrice = 0;
            if(newBoyButton.activeInHierarchy == false)
            {
                oldBoyButton.SetActive(false);
                newBoyButton.SetActive(true);
            }

            PlayerPrefs.SetInt("BoyBought", 1);
        }
        if(heroName == "Policeman") {
            gameManager.thirdSkinPrice = 0;
            if(newPolicemanButton.activeInHierarchy == false)
            {
                oldPolicemanButton.SetActive(false);
                newPolicemanButton.SetActive(true);
            }


            PlayerPrefs.SetInt("PolicemanBought", 1);
        }

    }

    public void ChooseHeroDefault()
    {
        PlayerPrefs.SetString("HeroChosen", "Player");
        print("Hero girl was chosen");
        girlBack.SetActive(true);
        policemanBack.SetActive(false);
        boyBack.SetActive(false);


    }
    public void ChooseHeroMan()
    {
        girlBack.SetActive(false);
        policemanBack.SetActive(false);
        boyBack.SetActive(true);
        PlayerPrefs.SetString("HeroChosen", "Boy");
        print("Hero boy was chosen");

    }
    public void ChooseHeroPoliceman()
    {
        girlBack.SetActive(false);
        policemanBack.SetActive(true);
        boyBack.SetActive(false);
        PlayerPrefs.SetString("HeroChosen", "Policeman");
        print("Hero policeman was chosen");

    }

    public void BuySkinsCoins()
    {
        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
        PlayerPrefs.SetInt("CurrentSkinCoins", skinsCount);
    }



}
