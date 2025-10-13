using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button1 : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick2);
    }

    void TaskOnClick2()
    {
        Debug.Log("pressed");
        SoulsManager.soulAmount += 5;
        SoulsManager.UpdateSouls();
    }
}
