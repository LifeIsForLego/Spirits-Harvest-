using UnityEngine;

public class UICarve : MonoBehaviour
{
    [SerializeField] bool carveMode;

    GameObject CarveUI1 = default;
    GameObject CarveUI2 = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CarveUI1 = transform.GetChild(0).gameObject;
        CarveUI2 = transform.GetChild(1).gameObject;

        CarveModeOff();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CarveModeOn()
    {
        carveMode = true;
        UpdateUI();

    }
    public void CarveModeOff()
    {
        carveMode= false;
        UpdateUI();
    }

    void UpdateUI()
    {
        if(carveMode)
        {
            CarveUI1.SetActive(true);
            CarveUI2.SetActive(true);
        }
        else
        {
            CarveUI1.SetActive(false);
            CarveUI2.SetActive(false);
        }
    }
}
