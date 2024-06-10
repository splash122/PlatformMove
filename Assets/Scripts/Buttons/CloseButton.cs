using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject settings;
    public GameObject ads;

    void Start()
    {
        settings = GameObject.FindWithTag("Settings");
        ads = GameObject.FindWithTag("CoinsNotEnoughWindow");
    }

    public void CloseSettings()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().canMove = true;
        settings.SetActive(false);
    }

    public void CloseAds()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().canMove = true;
        ads.SetActive(false);
    }
}
