using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string name;
    [System.NonSerialized]public float uses;

    public virtual void Use()
    {

    }

    public void addUse()
    {
        uses++;
    }
}
