using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public CoinsManager coinsmanager;


    public void Restart()
    {
        coinsmanager.DecrementIfRestart();
        Physics.gravity = new Vector3(0, -20, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
