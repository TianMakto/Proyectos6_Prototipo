﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Sprite used;

    bool playerOnSite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Locomotion>())
        {
            collision.GetComponent<Interact>().interactable = this;
        }
    }

    public void OpenDoor()
    {
        door.GetComponent<Door>().Open();
        GetComponent<SpriteRenderer>().sprite = used;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Locomotion>())
        {
            collision.GetComponent<Interact>().interactable = null;
        }
    }
}
