using UnityEngine;

public class Draw : MonoBehaviour
{
    
    public Camera camera;
    public int totalXpixels = 1024;
    public int totalYpixels = 512;
    public int brushSize = 4;
    public Color brushColour;

    public Transform topLeftCorner;
    public Transform bottomRightCorner;
    public Transform cursorPoint;

    public Material material;

    public Texture2D generatedTexture;

    Color[] colourMap;

    int xPixel = 0, yPixel = 0;
    float xMult, yMult;
    private void Start()
    {
        colourMap = new Color[totalXpixels * totalYpixels];
        generatedTexture = new Texture2D(totalYpixels, totalXpixels, TextureFormat.RGBA32, false);
        generatedTexture.filterMode = FilterMode.Point;
        material.SetTexture("_BaseMap", generatedTexture);

        ResetColour();

        xMult = totalXpixels / (bottomRightCorner.localPosition.x - topLeftCorner.localPosition.x);
        yMult = totalYpixels / (bottomRightCorner.localPosition.y - topLeftCorner.localPosition.y);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalculatePixel();
            
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
    }

    void ChangePixelsAroundPoint()
    {
        DrawBrush(xPixel, yPixel);
        SetTexture();
    }

    void DrawBrush(int xPix, int yPix)
    {
        int i = xPix - brushSize + 1, j = yPix - brushSize + 1, maxi = xPix + brushSize - 1, maxj = yPix + brushSize - 1;
        
        if (i < 0) i = 0;
        if (j < 0) j = 0;
        if (maxi >= totalXpixels) maxi = totalXpixels - 1;
        if (maxj >= totalYpixels) maxj = totalYpixels - 1;

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
            SetTexture();
        }   
    }
}
