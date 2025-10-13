using UnityEngine;

public class SoulsManager : MonoBehaviour
{
    public const string Souls = "Souls";
    public static int soulAmount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soulAmount = PlayerPrefs.GetInt("Souls");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateSouls()
    {
        PlayerPrefs.SetInt("Souls", soulAmount);
        soulAmount = PlayerPrefs.GetInt("Souls");
        PlayerPrefs.Save();
    }
}
