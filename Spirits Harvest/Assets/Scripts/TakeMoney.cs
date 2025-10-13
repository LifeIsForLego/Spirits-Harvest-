using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button2 : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("pressed");
        SoulsManager.soulAmount = 0;
        SoulsManager.UpdateSouls();
    }
}

