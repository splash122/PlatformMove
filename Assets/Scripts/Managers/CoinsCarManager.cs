using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsCarManager : MonoBehaviour
{
    private GameObject coinsSkin;
    public GameObject textNotEnough;
    public Text skinsText;
    public static int skinsCount = 0;
    //public int skinsCount = 0;
    private float resultProgress;
    public GameManager gameManager;

    public GameObject oldCarDefaultButton;
    public GameObject oldCar2Button;
    public GameObject oldCar3Button;
    public GameObject newDefaultButton;
    public GameObject newCar2Button;
    public GameObject newCar3Button;
    public GameObject defaultBack;
    public GameObject car2Back;
    public GameObject car3Back;


    // Start is called before the first frame update

    void Start()
    {
        skinsCount = PlayerPrefs.GetInt("CurrentSkinCoins", 0);
        coinsSkin = GameObject.FindWithTag("Coin");
        resultProgress = Mathf.Round(skinsCount);
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
        defaultBack = GameObject.Find("/Canvas/Default/ImageChosen");
        car2Back = GameObject.Find("/Canvas/Car2/ImageChosen2");
        car3Back = GameObject.Find("/Canvas/Car3/ImageChosen3");
        oldCarDefaultButton = GameObject.Find("/Canvas/Default/Image/ButtonDefault");
        oldCar2Button = GameObject.Find("/Canvas/Car2/Image/ButtonCar2");
        oldCar3Button = GameObject.Find("/Canvas/Car3/Image/ButtonCar3");
        newDefaultButton = GameObject.Find("/Canvas/Default/Image/ButtonNext");
        newCar2Button = GameObject.Find("/Canvas/Car2/Image/ButtonNext2");
        newCar3Button = GameObject.Find("/Canvas/Car3/Image/ButtonNext3");

    }

    public void DecrementIfSkinBought(int coinsForSkin, string carName)
    {

        if(skinsCount>=coinsForSkin){
            print("CarBought");
            print(carName);
            skinsCount -= coinsForSkin;
            resultProgress = Mathf.Round(skinsCount);
            skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
            CheckNewButtonActive(carName);
            PlayerPrefs.SetInt("CurrentSkinCoins", skinsCount);
        }
        else{
            print("No money");
            textNotEnough.SetActive(true);
        }

    }

    public void CheckNewButtonActive(string carName){
        if(carName == "Car2") {
            gameManager.secondSkinPrice = 0;
            if(newCar2Button.activeInHierarchy == false)
            {
                oldCar2Button.SetActive(false);
                newCar2Button.SetActive(true);
            }

            PlayerPrefs.SetInt("Car2Bought", 1);
        }
        if(carName == "Car3") {
            gameManager.thirdSkinPrice = 0;
            if(newCar3Button.activeInHierarchy == false)
            {
                oldCar3Button.SetActive(false);
                newCar3Button.SetActive(true);
            }


            PlayerPrefs.SetInt("Car3Bought", 1);
        }

    }

    public void ChooseCarDefault()
    {
        PlayerPrefs.SetString("CarChosen", "Default");
        print("Car default was chosen");
        defaultBack.SetActive(true);
        car2Back.SetActive(false);
        car3Back.SetActive(false);


    }
    public void ChooseCar2()
    {
        defaultBack.SetActive(false);
        car2Back.SetActive(true);
        car3Back.SetActive(false);
        PlayerPrefs.SetString("CarChosen", "Car2");
        print("Car2 was chosen");

    }
    public void ChooseCar3()
    {
        defaultBack.SetActive(false);
        car2Back.SetActive(false);
        car3Back.SetActive(true);
        PlayerPrefs.SetString("CarChosen", "Car3");
        print("Car3 was chosen");

    }

    public void BuySkinsCoins()
    {
        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
        PlayerPrefs.SetInt("CurrentSkinCoins", skinsCount);
    }
}
