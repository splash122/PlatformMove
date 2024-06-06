using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject settings;
    public GameObject ads;
    public Player player;
    void Start()
    {
        settings = GameObject.FindWithTag("Settings");
        ads = GameObject.FindWithTag("CoinsNotEnoughWindow");
    }

    public void CloseSettings()
    {
        player.canMove = true;
        settings.SetActive(false);
    }

    public void CloseAds()
    {
        player.canMove = true;
        ads.SetActive(false);
    }
}
