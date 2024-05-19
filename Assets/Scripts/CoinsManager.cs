using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    private GameObject coin;
    public Progressbar1 progressbar1;
    public Text coinsText;
    public static int coinsCount = 0;
    public static int neededCount;
    public float resultProgress;
    public GameManager gameManager;
    // Start is called before the first frame update

    void Start()
    {
        neededCount = gameManager.coinsForLevel;
        coin = GameObject.FindWithTag("Coin");
        coinsText.text = "Coins: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }

    public void IncrementCoins()
    {
        
        coinsCount += 1;
        coinsText.text = "Coins: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }

    public void DecrementCoins()
    {
        coinsCount -= neededCount;
        coinsText.text = "Coins: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }

    public void BuyCoins()
    {
        coinsCount += 20;
        progressbar1.IncrementProgress(20);
        coinsText.text = "Coins: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }
}
