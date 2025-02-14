using UnityEngine;
using TMPro;

public class CoinCode : MonoBehaviour
{
    public static CoinCode instance;
    public float Coin;
    public TextMeshProUGUI CoinText;
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        CoinText.text = Coin.ToString();
    }

    public void TakeObject(float Price)
    {
        Coin = Coin - Price;
    }

    public void SellObject(float Price)
    {
        Coin = Coin + (Price / 2);
    }

   
}
