using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkinsBuy : MonoBehaviour
{
    public CoinsSkinManager coinsSkinManager;
    public GameManager gameManager;

    public void DefaultHeroSkinsBuy(){
        coinsSkinManager.DecrementIfSkinBought(gameManager.firstSkinPrice);
    }
    public void SecondHeroSkinsBuy(){
        coinsSkinManager.DecrementIfSkinBought(gameManager.secondSkinPrice);
    }
    public void ThirdHeroSkinsBuy(){
        coinsSkinManager.DecrementIfSkinBought(gameManager.thirdSkinPrice);
    }
}
