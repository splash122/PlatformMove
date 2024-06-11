using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsSkinManager : MonoBehaviour
{
    private GameObject coinsSkin;
    public GameObject textNotEnough;
    public Text skinsText;
    public static int skinsCount = 0;
    //public int skinsCount = 0;
    private float resultProgress;
    public GameManager gameManager;
    public GameObject newGirlButton;
    public GameObject newBoyButton;
    public GameObject newPolicemanButton;


    // Start is called before the first frame update

    void Start()
    {
        coinsSkin = GameObject.FindWithTag("Coin");
        resultProgress = Mathf.Round(skinsCount);
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
        newGirlButton = GameObject.Find("/Canvas/Default/Image/ButtonNext");
        newBoyButton = GameObject.Find("/Canvas/Man/Image/ButtonNext2");
        newPolicemanButton = GameObject.Find("/Canvas/PoliceMan/Image/ButtonNext3");
        newGirlButton.SetActive(false);
        newBoyButton.SetActive(false);
        newPolicemanButton.SetActive(false);

    }

    public void IncrementSkinsCoins()
    {

        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
    }

    public void DecrementIfSkinBought(int coinsForSkin, string heroName)
    {
        if(skinsCount>=coinsForSkin){
            print("HeroBought");
            print(heroName);
            skinsCount -= coinsForSkin;
            resultProgress = Mathf.Round(skinsCount);
            skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
            PlayerPrefs.SetString("Hero", heroName);
            coinsForSkin = 0;
            if(heroName == "Player") {
                newGirlButton.SetActive(true);
            }
            //buttonBuyText = "Выбрать";

        }
        else{
            print("No money");
            textNotEnough.SetActive(true);
        }

    }

    public void BuySkinsCoins()
    {
        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
    }
}
