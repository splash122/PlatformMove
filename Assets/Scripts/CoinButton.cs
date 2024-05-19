using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinButton : MonoBehaviour
{
    public CoinsManager coinsText;
    public void CoinBuy()
    {
        coinsText.BuyCoins();
        print("Attempt to buy coins");
    }
}
