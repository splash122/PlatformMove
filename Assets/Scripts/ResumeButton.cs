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
}
