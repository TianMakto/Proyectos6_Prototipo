using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipItem : InventoryItem
{
    public override void Use()
    {
        if (uses > 0)
        {
            uses--;
            transform.parent.transform.Find("Hand/Weapon").GetComponent<Weapon>().Recharge();
            UI_Manager.Instance.setHP();
            UI_Manager.Instance.setCurrentObject(this);
        }

    }
}
