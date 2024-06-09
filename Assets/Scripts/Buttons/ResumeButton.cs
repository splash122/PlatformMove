using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public Player player;
    public void Resume()
    {
        //GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
        player.canMove = true;
        GameObject.FindWithTag("CoinsNotEnoughWindow").SetActive(false);

    }
    public void ResumeIfThingCollided()
    {
        //GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;

        GameObject.FindWithTag("Restart").SetActive(false);
        GameObject.FindWithTag("Thing").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
        player.canMove = true;

    }
}