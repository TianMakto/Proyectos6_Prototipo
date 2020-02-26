using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitInventory : InventoryItem
{
    [SerializeField] float healAmount = 30;
    public new float uses
    {
        get => medKitUses;
    }

    public override void Use()
    {
        if(medKitUses > 0)
        {
            medKitUses--;
            transform.parent.transform.parent.GetComponent<Life_Base>().Heal(healAmount);
            UI_Manager.Instance.setHP();
            UI_Manager.Instance.setCurrentObject(this);
        }

    }
}
