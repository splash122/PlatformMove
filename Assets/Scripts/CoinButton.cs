using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinButton : MonoBehaviour
{
    public void CoinBuy()
    {
        CoinsText.coinsCount += 20;
    }
}
