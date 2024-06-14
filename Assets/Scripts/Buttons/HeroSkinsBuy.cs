using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroSkinsBuy : MonoBehaviour
{
    public CoinsSkinManager coinsSkinManager;
    public GameManager gameManager;
    public GameObject textNotEnough;
    public TextMeshPro textMeshProBoy;
    public string heroName;


    public void DefaultHeroSkinsBuy(){
        heroName = "Player";
        //coinsSkinManager.DecrementIfSkinBought(gameManager.firstSkinPrice, heroName);
    }

    public void SecondHeroSkinsBuy(){
        heroName = "Boy";
        coinsSkinManager.DecrementIfSkinBought(gameManager.secondSkinPrice, heroName);


    }
    public void ThirdHeroSkinsBuy(){
        heroName = "Policeman";
        coinsSkinManager.DecrementIfSkinBought(gameManager.thirdSkinPrice, heroName);

    }


/*
    public void DefaultHeroSkinsBuy(){

        if (coinsSkinManager.skinsCount>= gameManager.firstSkinPrice){
            PlayerPrefs.SetString("Hero", "Player");
            coinsSkinManager.DecrementIfSkinBought(gameManager.firstSkinPrice);
            gameManager.firstSkinPrice = 0;

        }
        else{
            textNotEnough = GameObject.FindWithTag("CanvasCamera").GetComponent<HeroWindowController>().textNotEnough;
            textNotEnough.SetActive(true);
        }


    }
    public void SecondHeroSkinsBuy(){
        if (coinsSkinManager.skinsCount>= gameManager.secondSkinPrice){
            PlayerPrefs.SetString("Hero", "Boy");
            coinsSkinManager.DecrementIfSkinBought(gameManager.secondSkinPrice);
            gameManager.secondSkinPrice = 0;
            textMeshProBoy = GameObject.Find("/Canvas/Man/Image/ButtonMan/BoyText").GetComponent<TextMeshPro>();
            textMeshProBoy.text = "Выбрать";

        }
        else{
            textNotEnough = GameObject.FindWithTag("CanvasCamera").GetComponent<HeroWindowController>().textNotEnough;
            textNotEnough.SetActive(true);
        }
    }
    public void ThirdHeroSkinsBuy(){
        if (coinsSkinManager.skinsCount>= gameManager.thirdSkinPrice){
            PlayerPrefs.SetString("Hero", "Policeman");
            coinsSkinManager.DecrementIfSkinBought(gameManager.thirdSkinPrice);
            gameManager.thirdSkinPrice = 0;

        }
        else{
            textNotEnough = GameObject.FindWithTag("CanvasCamera").GetComponent<HeroWindowController>().textNotEnough;
            textNotEnough.SetActive(true);
        }
    }*/
}
