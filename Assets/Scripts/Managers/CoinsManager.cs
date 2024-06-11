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
        coin = GameObject.FindWithTag("Ticket");
        resultProgress = Mathf.Round(coinsCount)/Mathf.Round(neededCount);
        progressbar1.IncrementProgress(resultProgress);
        coinsText.text = "Билеты: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }

    public void IncrementCoins()
    {
        
        coinsCount += 1;
        resultProgress = Mathf.Round(coinsCount)/Mathf.Round(neededCount);
        progressbar1.IncrementProgress(resultProgress);
        coinsText.text = "Билеты: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }

    public void DecrementCoins()
    {
        coinsCount -= neededCount;
        resultProgress = Mathf.Round(coinsCount)/Mathf.Round(neededCount);
        progressbar1.IncrementProgress(resultProgress);
        coinsText.text = "Билеты: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }

    public void DecrementIfRestart()
    {
        coinsCount -= GameObject.FindWithTag("Player").GetComponent<Player>().gainedCoins;
        resultProgress = Mathf.Round(coinsCount)/Mathf.Round(neededCount);
        progressbar1.IncrementProgress(resultProgress);
        coinsText.text = "Билеты: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }

    public void BuyCoins()
    {
        coinsCount += 1;
        resultProgress = Mathf.Round(coinsCount)/Mathf.Round(neededCount);
        progressbar1.IncrementProgress(resultProgress);
        coinsText.text = "Билеты: " + Mathf.Round(coinsCount) + "/" + Mathf.Round(neededCount);
    }
}
