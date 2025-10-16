using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;

    [SerializeField] GameObject drawingPlace;
    Transform drawingTransform;

    [SerializeField] bool Carving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerInputs.GetInstance().gameObject;
        playerTransform = player.transform;

        drawingTransform = drawingPlace.transform;

        Carving = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraUpdate();
    }

    public void CarvingOn()
    {
        Carving = true;
    }
    public void CarvingOff()
    {
        Carving = false;
    }

    void CameraUpdate()
    {
        if(Carving)
        {
            transform.localPosition = drawingTransform.localPosition;
        }
        else
        {
            transform.localPosition = playerTransform.localPosition;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -10);
        }
    }
}
