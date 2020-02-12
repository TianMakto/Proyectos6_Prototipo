using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> inventory = new List<GameObject>();
    [SerializeField] GameObject currentObject;
    int index;

    private void Start()
    {
        currentObject = inventory[0];
        index = 0;
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            if(index < inventory.Count)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            currentObject = inventory[index];
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            if (index > 0)
            {
                index--;
            }
            else
            {
                index = inventory.Count - 1;
            }
        }
    }
}
