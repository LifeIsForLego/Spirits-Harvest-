using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public const string Coins = "Coins";
    public static int coinAmount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinAmount = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateCoins()
    {
        PlayerPrefs.SetInt("Coins", coinAmount);
        coinAmount = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.Save();
    }
}
