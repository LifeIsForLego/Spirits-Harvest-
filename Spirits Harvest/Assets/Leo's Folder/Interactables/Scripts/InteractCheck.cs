using System.Collections;
using UnityEngine;

public class InteractCheck : MonoBehaviour
{
    GameObject player;
    PlayerInputs inputs;
    PlayerManager manager;

    bool canInteract; //overlapping witht the player
    bool Interactable; //is currently able to be interacted with
    float Timer;

    [SerializeField]bool oneTime; //if true, then destroys itself on pickup
    [SerializeField]string item; //if it has an item attached to it, this is where the name of it is stored
    [SerializeField]int value; //if the player picks it up and obtains a multiple of the item this is how many items it is

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerInputs.GetInstance().gameObject;
        inputs = player.GetComponent<PlayerInputs>();
        manager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.playerMode)
        {
            if (canInteract && inputs.InteractInput)
            {
                manager.InteractionStart(item, value); //for the love of god put "null" and 0 if you want them blank
                if (oneTime)
                {
                    Timer = manager.GetInteractTick();
                    Debug.Log(Timer);
                    StartCoroutine(DeleteSelf());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    IEnumerator DeleteSelf()
    {
        yield return new WaitForSeconds(Timer);
        DestroySelf();
    }
}
