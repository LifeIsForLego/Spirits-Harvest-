using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SoulsDisplay : MonoBehaviour
{
    private Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string[] temp = text.text.Split('$');
        text.text = temp[0] + "$" + SoulsManager.soulAmount;
    }
}
