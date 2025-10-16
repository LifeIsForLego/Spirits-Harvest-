using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour 
{
    bool ENABLED;

    public Slider drawSlider;
    public float sliderReductionRate = 0.1f;
    public bool finishedButtonPressed = false;
    public Button finishedButton;

    public Camera camera;
    public int totalXpixels = 1024;
    public int totalYpixels = 512;
    public int brushSize = 4;
    public Color brushColour;

    public bool userInterpolation = true;

    public Transform topLeftCorner;
    public Transform bottomRightCorner;
    public Transform cursorPoint;

    public Material material;
    public Material finishedMaterial;

    public Texture2D generatedTexture;
   

    Color[] colourMap;

    int xPixel = 0, yPixel = 0;
    float xMult, yMult;

    bool pressedLastFrame = false;
    int lastX = 0;
    int lastY = 0;
    private void Start()
    {
        ENABLED = false;

        colourMap = new Color[totalXpixels * totalYpixels];
        generatedTexture = new Texture2D(totalYpixels, totalXpixels, TextureFormat.RGBA32, false);
        
        generatedTexture.filterMode = FilterMode.Point;
        Button btn = finishedButton.GetComponent<Button>();
        btn.onClick.AddListener(() => { finishedButtonPressed = true; });

        

        material.SetTexture("_MainTex", generatedTexture);
        
        drawSlider.maxValue = 1000; drawSlider.minValue = 0; drawSlider.value = 1000;

        ResetColour();

        xMult = totalXpixels / (bottomRightCorner.localPosition.x - topLeftCorner.localPosition.x);
        yMult = totalYpixels / (bottomRightCorner.localPosition.y - topLeftCorner.localPosition.y);
    }

    private void Update()
    {
        if (ENABLED)
        {
            if (Input.GetMouseButton(0))
            {
                if (drawSlider.value > 10 && finishedButtonPressed == false)
                {
                    // drawSlider.value = (int)(drawSlider.value) - 0.1f;
                    CalculatePixel();


                }
                else if (drawSlider.value < 10 || finishedButtonPressed == true)
                {
                    Debug.Log("Finished Drawing");
                    finishedMaterial.SetTexture("_MainTex", generatedTexture);


                }


            }
            else
            {
                pressedLastFrame = false;

            }
        }
    }
    void CalculatePixel()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 10f))
        {
           cursorPoint.position = hit.point;
            xPixel = (int)((cursorPoint.localPosition.x - topLeftCorner.localPosition.x) * totalXpixels / (bottomRightCorner.localPosition.x - topLeftCorner.localPosition.x));
            yPixel = (int)((cursorPoint.localPosition.y - topLeftCorner.localPosition.y) * totalYpixels / (bottomRightCorner.localPosition.y - topLeftCorner.localPosition.y));

            ChangePixelsAroundPoint();
        }
        else
        {
            pressedLastFrame = false;
            
        }
    }

    void ChangePixelsAroundPoint()
    {
        if (userInterpolation && pressedLastFrame && (lastX != xPixel || lastY != yPixel))
        {
            int dist = (int)Mathf.Sqrt((xPixel - lastX) * (xPixel - lastX) + (yPixel - lastY) * (yPixel - lastY));
            for (int i = 1; i <= dist; i++)
            {
                DrawBrush((i * xPixel + (dist - i) * lastX) / dist, (i * yPixel + (dist - i) * lastY) / dist);
                drawSlider.value -= sliderReductionRate;
            }
        }
        else
        {
            DrawBrush(xPixel, yPixel);
            drawSlider.value -= sliderReductionRate;

        }
            
        pressedLastFrame = true;
        lastX = xPixel;
        lastY = yPixel;
        SetTexture();
    }

    void DrawBrush(int xPix, int yPix)
    {
        int i = xPix - brushSize + 1, j = yPix - brushSize + 1, maxi = xPix + brushSize - 1, maxj = yPix + brushSize - 1;
        
        if (i < 0) 
            i = 0;

        if (j < 0)
            j = 0;

        if (maxi >= totalXpixels) 
            maxi = totalXpixels - 1;

        if (maxj >= totalYpixels) 
            maxj = totalYpixels - 1;

        for (int x = i; x <= maxi; x++)
        {
            for (int y = j; y <= maxj; y++)
            {
                if ((x - xPix) * (x - xPix) + (y - yPix) * (y - yPix) <= brushSize * brushSize)
                {
                    colourMap[x * totalYpixels + y] = brushColour;

                }
            }
        }
    }

    void SetTexture()
    {
        generatedTexture.SetPixels(colourMap);
        generatedTexture.Apply();
    }

    void ResetColour()
    {
        for(int i = 0; i < colourMap.Length; i++)
        {
            colourMap[i] = Color.white;
        }

        SetTexture();
    }

    public void ENABLEDON()
    {
        ENABLED = true;
    }
    public void ENABLEDOFF()
    {
        ENABLED = false;
    }
    public bool GETENABLED()
    {
        return ENABLED;
    }
}
