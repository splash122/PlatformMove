using UnityEngine;
using UnityEngine.UI;

public class CoinsSkinManager : MonoBehaviour
{
    private GameObject coinsSkin;
    public GameObject textNotEnough;
    public Text skinsText;
    public static int skinsCount = 0;
    private float resultProgress;
    public GameManager gameManager;

    // Start is called before the first frame update

    void Start()
    {
        coinsSkin = GameObject.FindWithTag("Coin");
        resultProgress = Mathf.Round(skinsCount);
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
        textNotEnough = GameObject.FindWithTag("MainCamera").GetComponent<HeroWindowController>().textNotEnough;

    }

    public void IncrementSkinsCoins()
    {

        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
    }

    public void DecrementIfSkinBought(int coinsForSkin)
    {
        if(skinsCount>=coinsForSkin){
            skinsCount -= coinsForSkin;
            resultProgress = Mathf.Round(skinsCount);
            skinsText.text = "Монеты: " + Mathf.Round(skinsCount);

        }
        else{
            textNotEnough.SetActive(true);
        }

    }

    public void BuySkinsCoins()
    {
        skinsCount += 1;
        skinsText.text = "Монеты: " + Mathf.Round(skinsCount);
    }
}
