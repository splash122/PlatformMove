using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinButton : MonoBehaviour
{
    public Player player;
    public CoinsManager coinsText;

    async void Start(){
        //player = GameObject.FindWithTag("Player").GetComponent<Player>;
    }
    public void CoinBuy()
    {
        coinsText.BuyCoins();
        print("Attempt to buy coins");
        //player.canMove = true;
    }
}
