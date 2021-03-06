﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<InventoryItem> inventory = new List<InventoryItem>();
    int index;
    [System.NonSerialized] public bool canUse;

    private void Start()
    {
        index = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<InventoryItem>())
            {
                if (transform.GetChild(i).GetComponent<MedkitInventory>())
                {
                    if(LevelManager.Instance.LevelType == typeOfLevel.Underground)
                        inventory.Add(transform.GetChild(i).GetComponent<InventoryItem>());
                }
                else
                    inventory.Add(transform.GetChild(i).GetComponent<InventoryItem>());
            }
        }
        canUse = true;
        //UI_Manager.Instance.setAmo(transform.Find("Hand/Weapon").GetComponent<Weapon>().GetAmmo());
        UI_Manager.Instance.setCurrentObject(inventory[index]);
        //UI_Manager.Instance.setMedkit(medkits);
    }

    public void TakeAClip()
    {
        transform.Find("Clip Item").GetComponent<InventoryItem>().addClipUse();
        print(inventory[index].name + ": " + inventory[index].uses);
        UI_Manager.Instance.setCurrentObject(inventory[index]);
        UI_Manager.Instance.setCurrentObject(inventory[index]);
    }

    public void TakeAMedkit()
    {
        transform.Find("Medkit Item").GetComponent<InventoryItem>().addMedkitUse();
        UI_Manager.Instance.setCurrentObject(inventory[index]);
        UI_Manager.Instance.setCurrentObject(inventory[index]);
    }

    private void Update()
    {

        if(Input.mouseScrollDelta.y < 0)
        {
            if (index > 0)
                index--;
            else
                index = inventory.Count - 1;
            UI_Manager.Instance.setCurrentObject(inventory[index]);
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            if (index < inventory.Count - 1)
                index++;
            else
                index = 0;
            UI_Manager.Instance.setCurrentObject(inventory[index]);
        }
        if (Input.GetKeyDown(KeyCode.E) && canUse)
        {
            inventory[index].Use();
        }

        UI_Manager.Instance.setCurrentObject(inventory[index]);
    }
}
