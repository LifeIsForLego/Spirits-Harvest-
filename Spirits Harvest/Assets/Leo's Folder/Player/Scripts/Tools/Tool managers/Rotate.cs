using UnityEngine;

public class Rotate : MonoBehaviour
{
    GameObject player;
    PlayerInputs inputs;

    string direction;

    float tiltangle;
    float halfangle;
    
    Quaternion north;
    Quaternion east;
    Quaternion south;
    Quaternion west;

    Quaternion northeast;
    Quaternion northwest;
    Quaternion southeast;
    Quaternion southwest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();

        tiltangle = 90f;
        halfangle = 45f;

        north = Quaternion.Euler(0, 0, tiltangle * 2);
        east = Quaternion.Euler(0, 0, tiltangle);
        south = Quaternion.Euler(0, 0, 0);
        west = Quaternion.Euler(0, 0, tiltangle * 3);

        northeast = Quaternion.Euler(0, 0, tiltangle + halfangle);
        northwest = Quaternion.Euler(0, 0, (tiltangle *2) + halfangle);

        southeast = Quaternion.Euler(0, 0, halfangle);
        southwest = Quaternion.Euler(0, 0, (tiltangle*3) + halfangle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotation(GameObject obj)
    {
        direction = inputs.GetDirection();

        if (direction == "North")
        {
            obj.transform.rotation = north;
        }
        else if (direction == "NorthEast")
        {
            obj.transform.rotation = northeast;
        }
        else if (direction == "East")
        {
            obj.transform.rotation = east;
        }
        else if (direction == "SouthEast")
        {
            obj.transform.rotation = southeast;
        }
        else if (direction == "South")
        {
            obj.transform.rotation = south;
        }
        else if (direction == "SouthWest")
        {
            obj.transform.rotation = southwest;
        }
        else if (direction == "West")
        {
            obj.transform.rotation = west;
        }
        else if (direction == "NorthWest")
        {
            obj.transform.rotation = northwest;
        }

        
    }
}
