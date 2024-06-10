using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkinsBuy : MonoBehaviour
{
    public CoinsSkinManager coinsSkinManager;
    public GameManager gameManager;

    public void DefaultHeroSkinsBuy(){
        coinsSkinManager.DecrementIfSkinBought(gameManager.firstSkinPrice);
        PlayerPrefs.SetString("Hero", "Player");
    }
    public void SecondHeroSkinsBuy(){
        coinsSkinManager.DecrementIfSkinBought(gameManager.secondSkinPrice);
        PlayerPrefs.SetString("Hero", "Boy");
    }
    public void ThirdHeroSkinsBuy(){
        coinsSkinManager.DecrementIfSkinBought(gameManager.thirdSkinPrice);
        PlayerPrefs.SetString("Hero", "Policeman");
    }
}
