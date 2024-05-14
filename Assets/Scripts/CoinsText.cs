using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    private GameObject coin;
    public Text coinsText;
    public static int coinsCount;
    public static int neededCount;
    // Start is called before the first frame update
    void Start()
    {
        coin = GameObject.FindWithTag("Coin");
        neededCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        coinsText.text = "Coins: " + Mathf.Round(coinsCount);
        if (coinsCount == neededCount) ;
    }
}
