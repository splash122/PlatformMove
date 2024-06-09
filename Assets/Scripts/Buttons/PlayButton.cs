using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void MoveToScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MoveToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void MoveToCars()
    {
        SceneManager.LoadScene("CarSkinsWindow");
    }

    public void MoveToHero()
    {
        SceneManager.LoadScene("HeroSkinsWindow");
    }

    public void MoveToGround()
    {
        SceneManager.LoadScene("GroundSkinsWindow");
    }

    public void MoveToBack()
    {
        SceneManager.LoadScene("BackSkinsWindow");
    }
}
