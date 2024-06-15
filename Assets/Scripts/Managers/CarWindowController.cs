using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWindowController : MonoBehaviour
{
    public GameObject textNotEnough;
    public CoinsCarManager coinsCarManager;

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
    void Start() {
        textNotEnough = GameObject.FindWithTag("TextNotEnough");
        textNotEnough.SetActive(false);
        defaultBack = GameObject.Find("/Canvas/Default/ImageChosen");
        car2Back = GameObject.Find("/Canvas/Car2/ImageChosen2");
        car3Back = GameObject.Find("/Canvas/Car3/ImageChosen3");
        defaultBack.SetActive(false);
        car2Back.SetActive(false);
        car3Back.SetActive(false);
        oldCarDefaultButton = GameObject.Find("/Canvas/Default/Image/ButtonDefault");
        oldCar2Button = GameObject.Find("/Canvas/Car2/Image/ButtonCar2");
        oldCar3Button = GameObject.Find("/Canvas/Car3/Image/ButtonCar3");
        newDefaultButton = GameObject.Find("/Canvas/Default/Image/ButtonNext");
        newCar2Button = GameObject.Find("/Canvas/Car2/Image/ButtonNext2");
        newCar3Button = GameObject.Find("/Canvas/Car3/Image/ButtonNext3");
        oldCarDefaultButton.SetActive(false);
        newDefaultButton.SetActive(true);
        newCar2Button.SetActive(false);
        newCar3Button.SetActive(false);

        if (PlayerPrefs.GetInt("Car2Bought") == 1) {
            print("Car2 bought earlier");
            coinsCarManager.CheckNewButtonActive("Car2");
        }
        if (PlayerPrefs.GetInt("Car3Bought") == 1) {
            print("Car3 bought earlier");
            coinsCarManager.CheckNewButtonActive("Car3");
        }
        if (PlayerPrefs.GetString("CarChosen") == "CarDefault") {
            coinsCarManager.ChooseCarDefault();
        }
        if (PlayerPrefs.GetString("CarChosen") == "Car2") {
            coinsCarManager.ChooseCar2();
        }
        if (PlayerPrefs.GetString("CarChosen") == "Car3") {
            coinsCarManager.ChooseCar3();
        }
    }
}
