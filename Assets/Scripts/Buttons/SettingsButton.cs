using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject settings;
    public Player player;

    public void Start()
    {
        settings = GameObject.FindWithTag("Settings");
        settings.SetActive(false);
    }


    public void SettingsWindow()
    {
        player.canMove = false;
        settings.SetActive(true);
    }


}
