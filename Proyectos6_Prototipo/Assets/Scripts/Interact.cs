using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [System.NonSerialized] public DoorControl interactable;

    // Update is called once per frame
    void Update()
    {
        if(interactable != null)
        {
            transform.Find("Inventory").GetComponent<Inventory>().canUse = false;
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.OpenDoor();
            }
        }
        else
        {
            transform.Find("Inventory").GetComponent<Inventory>().canUse = true;
        }
    }
}
