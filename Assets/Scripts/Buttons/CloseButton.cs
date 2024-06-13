using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject settings;
    public GameObject ads;
    public GameObject nextLevel;
    public GameObject[] things;

    void Start()
    {
        settings = GameObject.FindWithTag("Settings");
        ads = GameObject.Find("/CoinsNotEnough");
        nextLevel = GameObject.Find("/CoinsEnough");
    }

    public void CloseSettings()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().canMove = true;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
        things = GameObject.FindGameObjectsWithTag("Thing");

        foreach (GameObject thing in things)
        {
            thing.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        settings.SetActive(false);
    }

    public void CloseAds()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().canMove = true;
        ads.SetActive(false);
    }

    public void CloseNextLevel()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().canMove = true;
        nextLevel.SetActive(false);
    }
}
