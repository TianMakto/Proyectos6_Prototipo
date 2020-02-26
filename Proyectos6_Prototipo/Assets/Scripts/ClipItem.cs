using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipItem : InventoryItem
{
    public new float uses
    {
        get => clipUses;
    }
    public override void Use()
    {
        if (clipUses > 0)
        {
            clipUses--;
            transform.parent.transform.parent.transform.Find("Hand/Weapon").GetComponent<Weapon>().Recharge();
            UI_Manager.Instance.setHP();
            UI_Manager.Instance.setCurrentObject(this);
        }

    }
}
