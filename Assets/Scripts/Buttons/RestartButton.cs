using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public CoinsManager coinsManager;
    public CoinsSkinManager coinsSkinManager;


    public void Restart()
    {
        coinsManager.DecrementIfRestart();
        Physics.gravity = new Vector3(0, -20, 0);
        //PlayerPrefs.SetInt("CoinsGained",coinsSkinManager.skinsCount);
        print("CoinsGained");
        //print(coinsSkinManager.skinsCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
