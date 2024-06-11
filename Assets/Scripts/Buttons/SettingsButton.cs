using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject settings;
    public Player player;
    public GameObject[] things;

    public void Start()
    {

        settings = GameObject.FindWithTag("Settings");
        settings.SetActive(false);
    }


    public void SettingsWindow()
    {
        //player.canMove = false;
        settings.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
        things = GameObject.FindGameObjectsWithTag("Thing");

        foreach (GameObject thing in things)
        {
            thing.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        //GameObject.FindWithTag("Thing").GetComponent<Rigidbody>().isKinematic = true;
    }


}
