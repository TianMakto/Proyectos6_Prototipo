using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string name;

    [System.NonSerialized] public static float clipUses;
    [System.NonSerialized] public static float medKitUses;
    [System.NonSerialized] public static float knifeUses;


    [System.NonSerialized] public float uses;
    //public float Uses
    //{
    //    get => uses;
    //}

    public virtual void Use()
    {

    }

    public virtual void addClipUse()
    {
        clipUses++;
    }

    public virtual void addMedkitUse()
    {
        medKitUses++;
    }
}
