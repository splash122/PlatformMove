using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    public void Restart()
    {
        //CoinsManager.coinsCount = 0;
        Physics.gravity = new Vector3(0, -20, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
