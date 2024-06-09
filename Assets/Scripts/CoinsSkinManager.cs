using UnityEngine;
using UnityEngine.UI;

public class CoinsSkinManager : MonoBehaviour
{
    private GameObject coinsSkin;
    public Text skinsText;
    public static int skinsCount = 0;
    public float resultProgress;
    public GameManager gameManager;
    public Player player;
    // Start is called before the first frame update

    void Start()
    {
        coinsSkin = GameObject.FindWithTag("Coin");
        resultProgress = Mathf.Round(skinsCount);
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
    }

    public void IncrementSkinsCoins()
    {

        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
    }

    public void BuySkinsCoins()
    {
        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
    }
}
