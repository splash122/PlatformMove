using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarSkinsBuy : MonoBehaviour
{
    public CoinsCarManager coinsCarManager;
    public GameManager gameManager;
    public GameObject textNotEnough;
    public TextMeshPro textMeshProCar2;
    public string carName;


    public void DefaultCarSkinsBuy(){
        carName = "Default";
        //coinsSkinManager.DecrementIfSkinBought(gameManager.firstSkinPrice, heroName);
    }

    public void Car2SkinsBuy(){
        carName = "Car2";
        coinsCarManager.DecrementIfSkinBought(gameManager.secondCarPrice, carName);


    }
    public void Car3SkinsBuy(){
        carName = "Car3";
        coinsCarManager.DecrementIfSkinBought(gameManager.thirdCarPrice, carName);

    }
}
